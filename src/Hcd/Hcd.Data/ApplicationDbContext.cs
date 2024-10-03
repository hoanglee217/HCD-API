using Hcd.Data.Models;
using Microsoft.EntityFrameworkCore;
using Hcd.Data.Entities.Authentication;
using Hcd.Application.Common.Interfaces;

namespace Hcd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ICurrentUserService? currentUserService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;
                var now = DateTime.UtcNow;
                var userId = currentUserService?.GetCurrentUserId();

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = userId;
                }

                if (entry.State == EntityState.Modified)
                {
                    entity.UpdatedDate = now;
                    entity.UpdatedBy = userId;
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified; // Soft delete
                    entity.IsDeleted = true;
                    entity.DeletedDate = now;
                    entity.DeletedBy = userId;
                }
            }

            return base.SaveChanges();
        }
    }
}