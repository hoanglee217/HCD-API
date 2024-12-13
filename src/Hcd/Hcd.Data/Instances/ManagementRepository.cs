using System.Linq.Expressions;
using Hcd.Application.Common.Interfaces.Services;
using Hcd.Common.Base;
using Hcd.Common.Exceptions;
using Hcd.Common.Interfaces;
using Hcd.Common.Interfaces.Abstractions;

namespace Hcd.Data.Instances;

public class ManagementRepository<TEntity>(
    ApplicationDbContext context,
    ICurrentUserService currentUser,
    IDateTimeProvider dateTimeProvider
    )
    : RepositoryBase<TEntity, Guid>(context, currentUser.GetCurrentUserId(), dateTimeProvider), IManagementRepository<TEntity> 
    where TEntity : class
{
    private readonly ApplicationDbContext _context = context;

    public new IQueryable<TEntity> GetAll()
    {
        var data = base.GetAll();
        data = FilterResource(data);
        return data;
    }

    public new IQueryable<TEntity> Search(string? search)
    {
        var data = base.Search(search);
        data = FilterResource(data);
        return data;
    }
    public IQueryable<TEntity> GetAll(string? search, string? filter)
    {
        var data = Search(search);
        return data;
    }

    public new IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
    {
        var data = base.FindBy(predicate);
        data = FilterResource(data);
        return data;
    }

    public new async Task<TEntity?> FindAsync(Guid id)
    {
        if (id == default)
        {
            return null;
        }

        var entity = await base.FindAsync(id);

        return entity;
    }

    public new async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await base.FirstOrDefaultAsync(predicate);

        return entity;
    }

    public new virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        return await base.AddAsync(entity);
    }

    public new Task AddRangeAsync(List<TEntity> entities)
    {
        return base.AddRangeAsync(entities);
    }

    public new void UpdateRange(List<TEntity> entities)
    {
        base.UpdateRange(entities);
    }

    public new void AddRange(List<TEntity> entities)
    {
        base.AddRange(entities);
    }

    public new void RemoveRange(List<TEntity> entities)
    {
        base.RemoveRange(entities);
    }


    public new async Task<TEntity> Update(TEntity entity)
    {
        return await base.Update(entity);
    }

    public new TEntity Remove(Guid id)
    {
        var entity = Find(id);

        if (entity is null)
        {
            throw new NotFoundException("ENTITY_NOT_FOUND");
        }
        return base.Remove(id);
    }

    private IQueryable<TEntity> FilterResource(IQueryable<TEntity> data)
    {
        return data;
    }

}
