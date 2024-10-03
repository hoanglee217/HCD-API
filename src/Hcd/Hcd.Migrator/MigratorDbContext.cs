using Microsoft.EntityFrameworkCore;
using Hcd.Application.Common.Interfaces;
using Hcd.Data.Entities.Authentication;
using Hcd.Data.Models;

namespace Hcd.Migrator
{
    public class MigratorDbContext : DbContext
    {
        public ICurrentUserService? currentUserService;
        public MigratorDbContext(DbContextOptions<MigratorDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}