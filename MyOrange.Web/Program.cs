using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MyOrange.DbServices;
using Serilog;
using Serilog.Formatting.Compact;
using System;

namespace MyOrange.Web
{
    public class Program
    {
        // dotnet add package Serilog.AspNetCore

        public static void Main(string[] args)
        {

            // dotnet add package Serilog.AspNetCore

            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            // Konfiguracja za pomoc¹ metod
            Log.Logger = new LoggerConfiguration()
                //.WriteTo.Console()
                //.WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                //.WriteTo.File(new CompactJsonFormatter(), "logs/log.json")
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Application starting");

                 CreateHostBuilder(args).Build().Run();

                // EF
                //CreateHostBuilder(args).Build().MigrateDb<MyOrangeContext>().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The application failed to start correctly.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
    }
}
