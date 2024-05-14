using Domain;
using Application;
using Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using Api;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddPersistence(builder.Configuration); // Assuming AddPersistence is your method for adding persistence services
            builder.Services.AddApplication(); // Assuming AddApplication is your method for adding application services

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseMiddleware<CustomExceptionHandlerMiddleware>(); // Assuming ExceptionMiddleware is your custom exception middleware

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Register services
            services.AddSingleton<DomainService>(); // Assuming DomainService is your main domain service
            services.AddSingleton<ApplicationService>(); // Assuming ApplicationService is your main application service
            services.AddSingleton<PersistenceService>(); // Assuming PersistenceService is your main persistence service

            // Register other services as needed
            // services.AddScoped<IMyScopedService, MyScopedService>();
            // services.AddTransient<IMyTransientService, MyTransientService>();
        }

    }

    // Assuming these are your service classes
    public class DomainService { }
    public class ApplicationService { }
    public class PersistenceService { }
}