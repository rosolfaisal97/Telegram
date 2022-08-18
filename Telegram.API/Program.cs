using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Core.Constants;
using Telegram.Core.Repository;

namespace Telegram.API
{
    public class Program
    {
        public   static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var roleFactory = services.GetRequiredService<IRole>();
            var loginFactory = services.GetRequiredService<ILogin>();
            var userFactory = services.GetRequiredService<Iusers>();

             DefaultData.SeedAsync(roleFactory,userFactory, loginFactory);


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
