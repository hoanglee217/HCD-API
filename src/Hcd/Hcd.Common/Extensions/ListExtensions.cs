using System.Reflection;

namespace Hcd.Common.Extensions;

public static class ListExtensions
{
    public static List<T> OrderBy<T>(this List<T> source, string property)
    {
        return ApplyOrder<T>(source, property, false);
    }

    public static List<T> OrderByDescending<T>(
        this List<T> source,
        string property)
    {
        return ApplyOrder<T>(source, property, true);
    }

    static List<T> ApplyOrder<T>(
        List<T> source,
        string property,
        bool isDescending)
    {
        Type type = typeof(T);
        PropertyInfo? pi = type.GetProperty(property, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        if (pi == null)
        {
            throw new Exception("No property '" + property + "' in + " + type.Name + "'");
        }

        if (isDescending)
        {
            return source.OrderByDescending(o => pi.GetValue(o, null)).ToList();
        }

        return source.OrderBy(o => pi.GetValue(o, null)).ToList();
    }

    public static List<T> OrderByField<T>(this List<T> query, string orderBy = "id", string order = "asc")
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
}
