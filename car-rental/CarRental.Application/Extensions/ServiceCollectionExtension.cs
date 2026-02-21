using CarRental.Application.Common.Interfaces;
using CarRental.Application.Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        var appassembly = typeof(ServiceCollectionExtension).Assembly;
        services.AddAutoMapper(cfg => { }, appassembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(appassembly));

        services.AddScoped<IPasswordService, PasswordService>();
    }
}