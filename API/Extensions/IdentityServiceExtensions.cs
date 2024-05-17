using System.Text;
using Core.Entities.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services,
        IConfiguration config)
    {
        var builder = services.AddIdentityCore<AppUser>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 8;
        });

        builder.AddEntityFrameworkStores<AppIdentityDbContext>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme =
                options.DefaultChallengeScheme =
                    options.DefaultForbidScheme =
                        options.DefaultScheme =
                            options.DefaultSignInScheme =
                                options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = config["JWT:Issuer"],
                ValidateAudience = true,
                ValidAudience = config["JWT:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(config["JWT:SigninKey"]!)
                )
            };
        });
        
        return services;
    }
}