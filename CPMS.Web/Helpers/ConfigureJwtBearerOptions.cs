using System;
using System.Text;
using System.Threading.Tasks;
using CPMS.Common.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CPMS.Web.Helpers
{
    public class ConfigureJwtBearerOptions : IPostConfigureOptions<JwtBearerOptions>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ConfigureJwtBearerOptions(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void PostConfigure(string name, JwtBearerOptions options)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var configurationService = provider.GetRequiredService<IConfigurationService>();

                var jwtValue = configurationService.GetValue(ConfigurationKeys.JwtSecret);
                if (jwtValue == null)
                {
                    jwtValue = $"{Guid.NewGuid()}|{Guid.NewGuid()}|{Guid.NewGuid()}|{Guid.NewGuid()}";
                    configurationService.AddOrUpdateValue(ConfigurationKeys.JwtSecret, jwtValue);
                }

                var key = Encoding.UTF8.GetBytes(jwtValue);

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }

                        return Task.CompletedTask;
                    }
                };
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            }
        }
    }
}
