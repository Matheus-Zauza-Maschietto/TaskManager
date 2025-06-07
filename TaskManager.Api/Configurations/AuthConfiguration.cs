using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using TaskManager.Domain.Aggregates;
using TaskManager.Infra.PostgreSQL;

namespace TaskManager.Api.Configurations;

public static class AuthConfiguration
{
    public static void AddIdentityUserConfiguration(this IServiceCollection services)
    {
       services.AddIdentity<User, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false; 
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 3;
        })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }
    public static void AddAuthenticationConfiguration(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateActor = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JwtBearerTokenSettings:Issuer"],
                ValidAudience = configuration["JwtBearerTokenSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JwtBearerTokenSettings:SecretKey"] ?? "Secret Key não encontrada")
                )
            };
        });
    }

    public static void AddAuthorizationConfiguration(this IServiceCollection services, ConfigurationManager configuration)
    {
       services.AddAuthorization(options =>
        {
            options.FallbackPolicy = new AuthorizationPolicyBuilder()
            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser()
            .Build();
        });
    }
}
