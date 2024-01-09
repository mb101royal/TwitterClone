using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using TwitterClone.Core.Entities;
using TwitterClone.DatabaseAccessLayer.Contexts;

namespace TwitterClone.API
{
    public class Jwt
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Key { get; set; }
    }

    public static class ServiceRegistration
    {
        public static IServiceCollection AddUserIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<TwitterCloneDbContext>();

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, Jwt jwt)
        {
            services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,

                        ValidIssuer = jwt.Issuer,
                        ValidAudience = jwt.Audience,
                        LifetimeValidator = (active, expires, token, _) =>
                        token != null && expires > DateTime.UtcNow && active < DateTime.UtcNow
                    };
                });

            services.AddAuthorization();

            return services;
        }
    }
}
