using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Microsoft.IdentityModel.Tokens;

using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Core.Common;
using Telegram.Core.Repository;
using Telegram.Core.Service;
using Telegram.Infra.Common;

using Telegram.Infra.Repoisitory;
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
            services.AddCors(corsOptions =>

            {

                corsOptions.AddPolicy("policy",

                builder =>

                {

                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                });

            });

            services.AddControllers();

            //Data
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped< Iusers ,UserRepo>();
            services.AddScoped<IusersService, usersService>();
            services.AddScoped< IUserBlockList ,UserBlockRepo>();
            services.AddScoped<IuserBlockListService, userBlockListService>();
            services.AddScoped< IStory ,StoryRepo>();
            services.AddScoped<IStoryService, StoryService>();
            services.AddScoped< IRole ,RoleRepo>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped< ILogin ,LoginRepo>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

          ).AddJwtBearer(y =>
          {
              y.RequireHttpsMetadata = false;
              y.SaveToken = true;
              y.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                  ValidateIssuer = false,
                  ValidateAudience = false,

              };



          });
            services.AddScoped< IChatMessage ,ChatMassageRepo>();
            services.AddScoped<IChatMassageService, ChatMassageService>();

            //Repository
            services.AddScoped<IChannelRepository, ChannelRepository>();
            services.AddScoped<IChannelAdminRepository, ChannelAdminRepository>();
            services.AddScoped<IChannelMemberRepository, ChannelMemberRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostMediaRepository, PostMediaRepository>();
            services.AddScoped<IPostReportRepository, PostReportRepository>();
            services.AddScoped<IFunctionChannelAdminRepository, FunctionChannelAdminRepository>();
            services.AddScoped<IFunctionChannelUserRepository, FunctionChannelUserRepository>();
            services.AddScoped<IHomePageRepository, HomePageRepository>();

            //Service
            services.AddScoped<IChannelService, ChannelService>();
            services.AddScoped<IChannelAdminService, ChannelAdminService>();
            services.AddScoped<IChannelMemberService, ChannelMemberService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostMediaService, PostMediaService>();
            services.AddScoped<IPostReportService, PostReportService>();
            services.AddScoped<IFunctionChannelAdminService, FunctionChannelAdminService>();
            services.AddScoped<IFunctionChannelUserService, FunctionChannelUserService>();
            services.AddScoped<IHomePageService, HomePageService>();

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
            app.UseCors("policy");
            app.UseAuthentication();
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
