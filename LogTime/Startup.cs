using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using LogTime.Models;
using LogTime.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using LogTime.Utility;

namespace LogTime
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            using (var db = new TaskDbContext())
            {
                db.Database.EnsureCreated();
            }
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc((options =>
            {
                options.CacheProfiles.Add("Default",
                    new CacheProfile()
                    {
                        Duration = 60
                    });
                options.CacheProfiles.Add("LogTime",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.Any,
                        NoStore = true,
                        Duration = 60
                    });
            }));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
                options.DefaultForbidScheme = "JwtBearer";
            })
            .AddJwtBearer("JwtBearer", jwtBearerOption =>
            {
                jwtBearerOption.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(Constant.Serect)),

                    ValidateIssuer = true,
                    ValidIssuer = "LogTime.NetCore",

                    ValidateAudience = true,
                    ValidAudience = "LogTimeClient",

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
            services.AddCors(option =>
            {
                option.AddPolicy("AllowAllOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials();
                    });
            });
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.CookieName = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(2);
            });
            services.AddMemoryCache();
            services.AddMvc();
            services.AddDbContext<TaskDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            app.UseCors(builder =>
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                           .AllowCredentials()
                           .AllowAnyHeader());
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
