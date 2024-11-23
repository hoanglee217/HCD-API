﻿using Hcd.Common;
using Hcd.Migrator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static async Task Main(string[] args)
    {
        var connectionString = EnvMigrateLoader.LoadMigrateEnv();
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((services) =>
            {
                services.AddDbContext<MigratorDbContext>(options =>
                    options.UseMySql(
                        connectionString,
                        ServerVersion.AutoDetect(connectionString)
                    ));
            })
            .Build();

        await host.RunAsync();
    }
}
