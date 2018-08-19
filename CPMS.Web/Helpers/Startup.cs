using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CPMS.Common.EF;
using CPMS.Common.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace CPMS.Web.Helpers
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment env, IConfiguration config)
        {
            _env = env;
            _configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["CPMSConnectionString"];
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("Configuration property 'CPMSConnectionString' not found!");
            services.AddDbContext<DataContext>(x => x.UseMySql(connectionString));

            services.AddCors();

            services.AddMvc();

            services.AddAutoMapper();

            // configure strongly typed settings objects
            var appSettingsSection = _configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info { Title = "CPMS", Version = "v1" });
                config.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                config.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", Enumerable.Empty<string>() }
                });
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer();

            services.AddSingleton<IPostConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();


            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInterventionService, InterventionService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"); });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

            app.EnsureMigrationOfContext();
        }
    }

    public static class EnsureMigration
    {
        public static void EnsureMigrationOfContext(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetService<DataContext>();
                context.Database.Migrate();
            }
        }
    }
}
