using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyOrange.FakeServices;
using MyOrange.FakeServices.Fakers;
using MyOrange.IServices;
using MyOrange.Models;
using MyOrange.Models.Validations;

namespace MyOrange.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomerService, FakeCustomerService>();
            services.AddSingleton<Faker<Customer>, CustomerFaker>();

            services.AddSingleton<ICountryService, FakeCountryService>();

            services.AddSingleton<IDocumentService, FakeDocumentService>();
            services.AddSingleton<Faker<Document>, DocumentFaker>();


            services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(30));

            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true; // adres url malymi literami
                options.LowercaseQueryStrings = true; // parametry malymi literami
                options.AppendTrailingSlash = true; // dodaje ukosnik na koniec
            });

            // dotnet add package FluentValidation.AspNetCore
            // ręczna rejestracja walidatorów
            //   services.AddTransient<IValidator<Customer>, CustomerValidator>();
            //   services.AddTransient<IValidator<Document>, DocumentValidator>();

            // automatyczna rejestracja walidatorów
            services.AddRazorPages().AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<CustomerValidator>());

            

            // services.AddRazorPages(options => options.RootDirectory = "/Content");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            // Ustawienie domyślnego języka UI
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(Configuration["CurrentUICulture"]);

            // Ustawia lokalizacje na podstawie klienta
           // app.UseRequestLocalization();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
