using InventoryManamegent.Application.Interfaces;
using InventoryManamegent.Application.Mappings;
using InventoryManamegent.Application.Services;
using InventoryManamegent.Infra.Data.Context;
using InventoryManamegent.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManamegent.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase(configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Valide o appsettings.")));

        services.AddTransient<IDataSeeder, DataSeeder>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddAutoMapper(typeof(MappingProfile));

        // Popula banco de dados em memória.
        var serviceProvider = services.BuildServiceProvider();
        var dataSeeder = serviceProvider.GetRequiredService<IDataSeeder>();
        dataSeeder.SeedData();

        return services;
    }
}
