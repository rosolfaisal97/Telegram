using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Core.Common;
using Telegram.Core.Repository;
using Telegram.Core.Service;
using Telegram.Infra.Common;
using Telegram.Infra.Repository;
using Telegram.Infra.Service;

namespace Telegram.API
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
            services.AddControllers();
            //Data
            services.AddScoped<IDbContext, DbContext>();

            //Repository
            services.AddScoped<IChannelRepository, ChannelRepository>();
            services.AddScoped<IChannelAdminRepository, ChannelAdminRepository>();
            services.AddScoped<IChannelMemberRepository, ChannelMemberRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostMediaRepository, PostMediaRepository>();
            services.AddScoped<IPostReportRepository, PostReportRepository>();
            services.AddScoped<IFunctionChannelAdminRepository, FunctionChannelAdminRepository>();
            services.AddScoped<IFunctionChannelUserRepository, FunctionChannelUserRepository>();

            //Service
            services.AddScoped<IChannelService, ChannelService>();
            services.AddScoped<IChannelAdminService, ChannelAdminService>();
            services.AddScoped<IChannelMemberService, ChannelMemberService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostMediaService, PostMediaService>();
            services.AddScoped<IPostReportService, PostReportService>();
            services.AddScoped<IFunctionChannelAdminService, FunctionChannelAdminService>();
            services.AddScoped<IFunctionChannelUserService, FunctionChannelUserService>();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "<title>", Version = "v1" });
            }); 
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                "<title> v1")); app.UseSwagger();
           
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
