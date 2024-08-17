using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Peresistence.Data;

using Microsoft.EntityFrameworkCore;
using Core.Shared;
using Infrastructure.Peresistence.Shared;
using Application.Identity;
using Infrastructure.Infrastructure.Helpers.Middlewares;
using ReceiptManagment.Core.Receipt;
using ReceiptManagment.Infrastructure.Peresistence.ReceiptManagment;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var ConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.Configure<Jwt>(cfg => configuration.GetSection("JWT"));
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(ConnectionString , ServerVersion.AutoDetect(ConnectionString))
            );
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ExceptionHandlingMiddleware>();
           // services.AddScoped<IIdentityService,IdentityService>();
           
           
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IReceiptRepository, ReceiptRepository>();
           


           




            return services;
        }
    }
}
