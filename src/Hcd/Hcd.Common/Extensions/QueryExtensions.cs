using System.Linq.Expressions;
using System.Reflection;

namespace Hcd.Common.Extensions;

public static class QueryExtensions
{
    public static IOrderedQueryable<T> OrderBy<T>(
this IQueryable<T> source,
string property)
    {
        return ApplyOrder<T>(source, property, "OrderBy");
    }

    public static IOrderedQueryable<T> OrderByDescending<T>(
        this IQueryable<T> source,
        string property)
    {
        return ApplyOrder<T>(source, property, "OrderByDescending");
    }

    public static IOrderedQueryable<T> ThenBy<T>(
        this IOrderedQueryable<T> source,
        string property)
    {
        return ApplyOrder<T>(source, property, "ThenBy");
    }

    public static IOrderedQueryable<T> ThenByDescending<T>(
        this IOrderedQueryable<T> source,
        string property)
    {
        return ApplyOrder<T>(source, property, "ThenByDescending");
    }

    static IOrderedQueryable<T> ApplyOrder<T>(
        IQueryable<T> source,
        string property,
        string methodName)
    {
        string[] props = property.Split('.');
        Type type = typeof(T);
        ParameterExpression arg = Expression.Parameter(type, "x");
        Expression expr = arg;
        foreach (string prop in props)
        {
            // use reflection (not ComponentModel) to mirror LINQ
            PropertyInfo? pi = type.GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (pi == null)
            {
                throw new Exception("No property '" + prop + "' in + " + type.Name + "'");
            }

            expr = Expression.Property(expr, pi);
            type = pi.PropertyType;
        }
        Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
        LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

        var orderMethodInfo = typeof(Queryable).GetMethods().Single(
                method => method.Name == methodName
                        && method.IsGenericMethodDefinition
                        && method.GetGenericArguments().Length == 2
                        && method.GetParameters().Length == 2) ?? throw new Exception();


        var genericMethod = orderMethodInfo.MakeGenericMethod(typeof(T), type) ?? throw new Exception();
        object? result = genericMethod.Invoke(null, [source, lambda]) ?? throw new Exception();
        return (IOrderedQueryable<T>)result;
    }

    public static IQueryable<T> OrderByField<T>(this IQueryable<T> query, string orderBy = "id", string order = "asc")
    {
        PropertyInfo? property = typeof(T).GetProperty(orderBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        if (property != null)
        {
            if (order.ToLower().Equals("asc"))
            {
                query = query.OrderBy(orderBy);
            }
            else
            {
                query = query.OrderByDescending(orderBy);
            }
        }
        return query;
    }

    public static IQueryable<TEntity> QuerySearchable<TEntity, TAttribute>(this IQueryable<TEntity> query, string searchTerm)
{
    if (string.IsNullOrWhiteSpace(searchTerm)) return query; // Skip if empty

    var entityType = typeof(TEntity);
    var parameter = Expression.Parameter(entityType, "x");

    var searchableProperties = entityType.GetProperties()
        .Where(p => p.GetCustomAttributes(typeof(TAttribute), true).Any() && p.PropertyType == typeof(string))
        .ToList();

    if (!searchableProperties.Any())
    {
        return query;
    }

    Expression? predicate = null;
    var searchExpression = Expression.Constant(searchTerm, typeof(string));
    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) }) ?? throw new InvalidOperationException("String.Contains method not found");

    foreach (var property in searchableProperties)
    {
        var propertyAccess = Expression.Property(parameter, property);
        var containsCall = Expression.Call(propertyAccess, containsMethod, searchExpression);

        predicate = predicate == null ? containsCall : Expression.OrElse(predicate, containsCall);
    }

    var lambda = Expression.Lambda<Func<TEntity, bool>>(predicate!, parameter);
    return query.Where(lambda);
}
}
