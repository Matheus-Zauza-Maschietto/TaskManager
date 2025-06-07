using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Application.Common.Services.Contracts;

namespace TaskManager.Application.Common.Services;

public class JWTService(
    IConfiguration Configuration
) : IJWTService
{
    public string GenerateToken(Claim[] claims)
    {
        var jwtSettings = Configuration.GetSection("JwtBearerTokenSettings");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        string expirationTime = jwtSettings["ExpiryTimeInMinutes"]?.ToString() ?? "0";
        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(int.Parse(expirationTime)),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
