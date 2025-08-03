using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DatingAPP_API.Extensions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services,IConfiguration configuration) { 
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x => {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                ValidateAudience = false,
            };
        });
            return services;
        }
    }
}
