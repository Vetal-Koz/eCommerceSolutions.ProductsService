using eCommerce.Core.RepositoryContracts;
using eCommerce.Infastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfastructure(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
    
}