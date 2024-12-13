﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Hcd.Common.Interfaces.Abstractions;
using Hcd.Common.Interfaces;
using Hcd.Application.Common.Interfaces.Services;

namespace Hcd.Common.Base;

public abstract class UnitOfWorkBase<TContext>(
    TContext context,
    IServiceProvider serviceProvider
    ) : IUnitOfWork where TContext : DbContext
{
    private ICurrentUserService CurrentUserService => serviceProvider.GetRequiredService<ICurrentUserService>();
    private IDateTimeProvider DateTimeProvider => serviceProvider.GetRequiredService<IDateTimeProvider>();
    public async Task BeginTransactionAsync()
    {
        await context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await context.Database.CommitTransactionAsync();
    }

    public virtual void Dispose()
    {
        context.Database.CurrentTransaction?.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task RollbackTransactionAsync()
    {
        await context.Database.RollbackTransactionAsync();
    }

    public async Task SaveChangesAsync()
    {
        var states = new[] { EntityState.Added, EntityState.Deleted, EntityState.Modified };

        var changeEntities = context.ChangeTracker
            .Entries().Where(e => states.Contains(e.State))
            .ToList();

        await context.SaveChangesAsync();

        await AfterSaveChangeAsync();
    }

    private async Task AfterSaveChangeAsync()
    {
        // try
        // {
        //     foreach (var entity in changeIModelEntities)
        //     {
        //         var DeleterId = entity.DataChanges?.FirstOrDefault(e => e.Field == "DeleterId")?.ChangedValue;

        //         if(entity.State == EntityState.Added)
        //         {
        //             await publisher.Publish(new ModelCreateEventRequest<IModel>() { 
        //                 Data = (IModel)entity.Entity, 
        //                 DataChanges = entity.DataChanges
        //             });
        //         }
        //         else if(entity.State == EntityState.Deleted || DeleterId != null)
        //         {
        //             await publisher.Publish(new ModelDeleteEventRequest<IModel>() { 
        //                 Data = (IModel)entity.Entity,
        //                 DataChanges = entity.DataChanges
        //             });
        //         }
        //         else if(entity.State == EntityState.Modified && DeleterId == null)
        //         {
        //             await publisher.Publish(new ModelModifyEventRequest<IModel>() { 
        //                 Data = (IModel)entity.Entity,
        //                 DataChanges = entity.DataChanges
        //             });
        //         }
        //     }

        //     if (auditDocuments != null && auditDocuments.Count != 0)
        //     {
        //         var auditSystemLog = new AuditSystemLog
        //         {
        //             Documents = auditDocuments
        //         };

        //         await publisher.Publish(new SaveAsyncLogEventRequest<ISystemLog>() { Data = auditSystemLog });
        //     }
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e);
        // }
        
    }
}
