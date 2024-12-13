using System.Linq.Expressions;
using Hcd.Application.Common.Interfaces.Services;
using Hcd.Common.Attributes;
using Hcd.Common.Exceptions;
using Hcd.Common.Extensions;
using Hcd.Common.Interfaces.Abstractions.Auditing;
using Microsoft.EntityFrameworkCore;

namespace Hcd.Common.Base;

public abstract class Repository<TEntity, TKey>(IDateTimeProvider dateTimeProvider)
    where TEntity : class
{
    public IDateTimeProvider DateTimeService { get; } = dateTimeProvider;
}
public abstract class RepositoryBase<TEntity, TKey>(
    DbContext dbContext,
    Guid userId,
    IDateTimeProvider dateTimeProvider)
    : Repository<TEntity, TKey>(dateTimeProvider)
    where TEntity : class
{
    public Guid UserId { get; } = userId;

    public void SetCreateAuditProperties(TEntity entity)
    {
        if (entity is not ICreationAuditedObject createAuditProperties)
        {
            return;
        }

        createAuditProperties.CreatorId = this.UserId;
        createAuditProperties.CreationTime = this.DateTimeService.UtcNow;
    }

    public void SetUpdateAuditProperties(TEntity entity)
    {
        if (entity is not IModificationAuditedObject updateAuditProperties)
        {
            return;
        }

        updateAuditProperties.LastModifierId = this.UserId;
        updateAuditProperties.LastModificationTime = this.DateTimeService.UtcNow;
    }

    public bool SetDeleteAuditProperties(TEntity entity)
    {
        if (entity is not IDeletionAuditedObject deleteAuditProperties)
        {
            return false;
        }

        deleteAuditProperties.DeleterId = this.UserId;
        deleteAuditProperties.DeletionTime = this.DateTimeService.UtcNow;

        return true;
    }
    public IQueryable<TEntity> Search(string? searchTerm)
    {
        var data = GetAll();
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return data;
        }

        return data.QuerySearchable<TEntity, SearchableAttribute>(searchTerm);
    }

    public IQueryable<TEntity> GetAll()
    {
        var data = dbContext.Set<TEntity>().AsQueryable();
        return data;
    }
    public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
    {
        return dbContext.Set<TEntity>().Where(predicate);
    }

    public TEntity? Find(TKey id)
    {
        var item = dbContext.Set<TEntity>().Find(id);
        return item;
    }
    public async Task<TEntity?> FindAsync(TKey id)
    {
        if (id == null)
        {
            return null;
        }

        var item = await dbContext.Set<TEntity>().FindAsync(id);
        return item;
    }

    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        this.SetCreateAuditProperties(entity);
        await dbContext.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public Task<TEntity> Update(TEntity entity)
    {
        this.SetUpdateAuditProperties(entity);
        dbContext.Set<TEntity>().Update(entity);
        return Task.FromResult(entity);
    }

    public async Task AddRangeAsync(List<TEntity> entities)
    {
        entities.ForEach(this.SetCreateAuditProperties);
        await dbContext.Set<TEntity>().AddRangeAsync(entities);
    }

    public void UpdateRange(List<TEntity> entities)
    {
        entities.ForEach(this.SetUpdateAuditProperties);
        dbContext.Set<TEntity>().UpdateRange(entities);
    }

    public void AddRange(List<TEntity> entities)
    {
        entities.ForEach(this.SetCreateAuditProperties);
        dbContext.Set<TEntity>().AddRange(entities);
    }

    public TEntity Remove(TKey id)
    {
        var entity = dbContext.Set<TEntity>().Find(id);

        if (entity is null)
        {
            throw new NotFoundException("ENTITY_NOT_FOUND");
        }

        var isSoftDelete = this.SetDeleteAuditProperties(entity);
        if (isSoftDelete)
        {
            dbContext.Set<TEntity>().Update(entity);
        }
        else
        {
            dbContext.Set<TEntity>().Remove(entity);
        }
        return entity;
    }

    public void RemoveRange(List<TEntity> entities)
    {
        List<TEntity> hardDeleted = new List<TEntity>();
        List<TEntity> softDeleted = new List<TEntity>();
        entities.ForEach(e =>
        {
            var isSoftDelete = this.SetDeleteAuditProperties(e);
            if (isSoftDelete)
            {
                softDeleted.Add(e);
            }
            else
            {
                hardDeleted.Add(e);
            }
        });
        UpdateRange(softDeleted);
        dbContext.Set<TEntity>().RemoveRange(hardDeleted);
    }


}
