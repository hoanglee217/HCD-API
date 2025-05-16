using Hcd.Data.Models;
using Microsoft.EntityFrameworkCore;
using Hcd.Data.Entities.Authentication;
using Hcd.Data.Entities.Management;
using Hcd.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using Hcd.Data.Entities.System;

namespace Hcd.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public ICurrentUserService? currentUserService;

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.Email })
                .IsUnique();
            base.OnModelCreating(modelBuilder);
            // Apply Global Query Filter
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(ApplicationDbContext)
                        .GetMethod(nameof(SetQueryFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)?
                        .MakeGenericMethod(entityType.ClrType);

                    method?.Invoke(null, new object[] { modelBuilder });
                }
            }
        }

        private static void SetQueryFilter<T>(ModelBuilder modelBuilder) where T : BaseEntity
        {
            modelBuilder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }
        // public override int SaveChanges()
        // {
        //     var entries = ChangeTracker
        //         .Entries()
        //         .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

        //     foreach (var entry in entries)
        //     {
        //         var entity = (BaseEntity)entry.Entity;
        //         var now = DateTime.UtcNow;
        //         var userId = currentUserService?.GetCurrentUserId();

        //         if(entity.CreatedDate != null){
        //             entity.CreatedDate = now;
        //         }

        //         if (entry.State == EntityState.Added)
        //         {
        //             entity.CreatedDate = now;
        //             entity.CreatedBy = userId;
        //         }

        //         if (entry.State == EntityState.Modified)
        //         {
        //             entity.UpdatedDate = now;
        //             entity.UpdatedBy = userId;
        //         }

        //         if (entry.State == EntityState.Deleted)
        //         {
        //             entry.State = EntityState.Modified; // Soft delete
        //             entity.IsDeleted = true;
        //             entity.DeletedDate = now;
        //             entity.DeletedBy = userId;
        //         }
        //     }

        //     return base.SaveChanges();
        // }
    }
}