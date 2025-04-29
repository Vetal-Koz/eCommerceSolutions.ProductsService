using eCommerce.Core.RabbitMQ;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        
        services.AddTransient<IRabbitMQPublisher, RabbitMQPublisher>();
        
        return services;
    }
}