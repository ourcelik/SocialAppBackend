using Business.Abstract;
using Business.Concrete;
using Business.Hubs;
using Business.Hubs.Abstract;
using Business.Subscriptions.SqlTableDependency;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Subcriptions.SqlTableDependency;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialAppWebApi
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
            services.AddCors(option => option.AddDefaultPolicy(policy
                => policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetIsOriginAllowed(origin => true)
                ));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialAppWebApi", Version = "v1" });
            });
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                    options.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = (context) =>
                         {
                             var accessToken = context.Request.Query["access_token"];
                             if (!string.IsNullOrEmpty(accessToken))
                             {
                                 context.Token = accessToken;
                             }
                             return Task.CompletedTask;
                         }
                            
                    };
                });
            services.AddSignalR();
            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(),
                new SubscriptionModule(typeof(DatabaseSubscription<>),new Type[] { typeof(UserNotificationStatistic),typeof(CommentNotification) })
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IUserNotificationService userNotificationService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialAppWebApi v1"));
            }
            app.ConfigureCustomExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseCors();
            //typeof(DatabaseSubscription<>),new Type[] { typeof(UserNotificationStatistic), typeof(CommentNotification) }
            app.ConfigureDatabaseSubscription(new DatabaseSubscriptionOptions()
            {
                SubscriptionType = typeof(DatabaseSubscription<>),
                TableTypes = new Type[] { typeof(UserNotificationStatistic), typeof(CommentNotification) }
            });
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();
            userNotificationService._hubContext =(IHubContext<UserNotificationHub, IUserNotificationHub>)app.ApplicationServices.GetService(typeof(IHubContext<UserNotificationHub, IUserNotificationHub>));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<UserNotificationHub>("/userNotificationHub");
            });
        }
    }
}
