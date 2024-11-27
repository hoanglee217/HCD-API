using Hcd.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Hcd.Migrator
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MigratorDbContext>
    {
        public MigratorDbContext CreateDbContext(string[] args)
        {
            var connectionString = EnvMigrateLoader.LoadMigrateEnv();
            var optionsBuilder = new DbContextOptionsBuilder<MigratorDbContext>();

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new MigratorDbContext(optionsBuilder.Options);
        }
    }
}