using DatingAPP_API.Data;
using DatingAPP_API.Interface;
using DatingAPP_API.Service;
using Microsoft.EntityFrameworkCore;

namespace DatingAPP_API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicaionService(this IServiceCollection Services, IConfiguration configuration) {
            Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
            });
            Services.AddScoped<ITokenService, TokenService>();

            return Services;
        }
    }
}
