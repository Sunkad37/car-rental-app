using CarRental.Infrastructure.Persistence;
using CarRental.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddDbContext<AppDbContext>(options 
            => options.UseSqlServer(configuration.GetConnectionString("CarRentalConnectionString")));
    }
}