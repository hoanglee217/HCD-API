#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
using Microsoft.EntityFrameworkCore;
using Hcd.Application.Common.Interfaces;
using Hcd.Data.Entities.Authentication;
using Hcd.Data.Models;
using Hcd.Data.Entities.Management.Blog;

namespace Hcd.Migrator
{
    public class MigratorDbContext(DbContextOptions<MigratorDbContext> options) : DbContext(options)
    {
        public ICurrentUserService? currentUserService;

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}