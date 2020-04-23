using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyOrange.DbServices;

namespace MyOrange.Web
{
    public static class DbHostExtensions
    {
        public static IHost CreateDbIfNotExists<TContext>(this IHost host)
            where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<MyOrangeContext>();

                try
                {
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Create database error");
                }

            }

            return host;
        }


        public static IHost MigrateDb<TContext>(this IHost host)
        where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<TContext>();

                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Apply migration has failed");
                }

            }

            return host;
        }

    }
}
