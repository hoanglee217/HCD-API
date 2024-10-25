using Hcd.Data.Models;
using Microsoft.EntityFrameworkCore;
using Hcd.Data.Entities.Authentication;
using Hcd.Application.Common.Interfaces;
using Hcd.Data.Entities.Management.Blog;

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
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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