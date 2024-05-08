using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting;
using System;
using Application;
using Microsoft.Extensions.Logging;
using Persistence;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore.Internal;
using Application.Interfaces;
namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new HostBuilder().Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<PerDbContext>();
                //context.Database.EnsureCreated();
            }

            host.Run();
        }
    }
}



  