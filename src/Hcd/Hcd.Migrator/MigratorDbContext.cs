using Microsoft.EntityFrameworkCore;
using Hcd.Data.Entities.Authentication;
using Hcd.Data.Models;
using Hcd.Data.Entities.Management;
using Hcd.Common.Interfaces;
using Hcd.Data.Entities.System;

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
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}