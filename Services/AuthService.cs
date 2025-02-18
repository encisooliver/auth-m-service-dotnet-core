using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using auth_project.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using auth_project.Interfaces;

namespace auth_project.Services;

public class AuthService: IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJwtToken(UserModel user)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");
            var secretKey = jwtSettings.GetValue<String>("Key");
            var issuer = jwtSettings.GetValue<String>("Issuer");
            var audience = jwtSettings.GetValue<String>("Audience");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
}
