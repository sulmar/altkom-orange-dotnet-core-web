using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyOrange.DbServices;

namespace MyOrange.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);
            
            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<MyOrangeContext>();

                // context.Database.EnsureDeleted();
                // context.Database.EnsureCreated();

                context.Database.Migrate();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
