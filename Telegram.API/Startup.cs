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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
