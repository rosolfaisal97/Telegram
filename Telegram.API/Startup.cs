using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
            //CORS API
            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("policy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });

            });

            //Auth
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(y =>
            {
                y.RequireHttpsMetadata = false;
                y.SaveToken = true;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(Configuration["jwt:key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidAudience = Configuration["jwt:Audience"],
                    ValidIssuer = Configuration["jwt:Issuer"],
                   
                };
                
            });


            services.AddControllers();
            //Data
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<Iusers, UserRepo>();
            services.AddScoped<IusersService, usersService>();
            services.AddScoped<IUserBlockList, UserBlockRepo>();
            services.AddScoped<IuserBlockListService, userBlockListService>();
            services.AddScoped<IStory, StoryRepo>();
            services.AddScoped<IStoryService, StoryService>();
            services.AddScoped<IRole, RoleRepo>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITestimonial, TestimonialRepo>();
            services.AddScoped<ITestimonialcs, TestimonialService>();
            services.AddScoped<ILogin, LoginRepo>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IServicesService, ServicesService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();

            //Repository
            services.AddScoped<IChatMessage, ChatMassageRepo>();
            services.AddScoped<IChatMassageService, ChatMassageService>();
            services.AddScoped<IChannelRepository, ChannelRepository>();
            services.AddScoped<IChannelAdminRepository, ChannelAdminRepository>();
            services.AddScoped<IChannelMemberRepository, ChannelMemberRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostMediaRepository, PostMediaRepository>();
            services.AddScoped<IPostReportRepository, PostReportRepository>();
            services.AddScoped<IFunctionChannelAdminRepository, FunctionChannelAdminRepository>();
            services.AddScoped<IFunctionChannelUserRepository, FunctionChannelUserRepository>();
            services.AddScoped<IFriendsRepository, FriendsRepository>();
            services.AddScoped<ICommentsRepository, CommentsRepository>();
            services.AddScoped<IReactionRepository, ReactionRepository>();
            services.AddScoped<IMediaMsgRepository, MediaMsgRepository>();
            services.AddScoped<IHomePageRepository, HomePageRepository>();
            services.AddScoped<IStoryReportRepository, StoryReportRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<ISERVICESRepository,SERVICESRepository>();
            //Service
            services.AddScoped<IChannelService, ChannelService>();
            services.AddScoped<IChannelAdminService, ChannelAdminService>();
            services.AddScoped<IChannelMemberService, ChannelMemberService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostMediaService, PostMediaService>();
            services.AddScoped<IPostReportService, PostReportService>();
            services.AddScoped<IFunctionChannelAdminService, FunctionChannelAdminService>();
            services.AddScoped<IFunctionChannelUserService, FunctionChannelUserService>();
            services.AddScoped<IFriendsService, FriendsService>();
            services.AddScoped<ICommentsService, CommentsService>();
            services.AddScoped<IReactionService, ReactionService>();
            services.AddScoped<IMediaMsgService, MediaMsgService>();
            services.AddScoped<IHomePageService, HomePageService>();
            services.AddScoped<IStoryReportService, storyReportService>();

            //osama
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IGrouoAdminRepository, GrouoAdminRepository>();
            services.AddScoped<IGroupLinkRepository, GroupLinkRepository>();
            services.AddScoped<IGroupMemberRepository, GroupMemberRepository>();
            services.AddScoped<IGroupMessageRepositoty, GroupMessageRepositoty>();
            services.AddScoped<IGroupsRepository, GroupsRepository>();
            services.AddScoped<IMediaGroupRepositery, MediaGroupRepositery>();
            services.AddScoped<IGrouoAdminService, GrouoAdminService>();
            services.AddScoped<IGroupLinkService, GroupLinkService>();
            services.AddScoped<IGroupMemberService, GroupMemberService>();
            services.AddScoped<IGroupMessageService, GroupMessageService>();
            services.AddScoped<IGroupsService, GroupsService>();
            services.AddScoped<IMediaGroupRepositery, MediaGroupRepositery>();

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
                "<title> v1"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
