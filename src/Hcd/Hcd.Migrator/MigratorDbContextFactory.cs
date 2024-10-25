using Hcd.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Hcd.Migrator
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MigratorDbContext>
    {
        public MigratorDbContext CreateDbContext(string[] args)
        {
            EnvLoader.LoadEnv();

            var optionsBuilder = new DbContextOptionsBuilder<MigratorDbContext>();
            optionsBuilder.UseMySql(
                Env.ConnectionString, 
                ServerVersion.AutoDetect(Env.ConnectionString));

            return new MigratorDbContext(optionsBuilder.Options);
        }
    }
}