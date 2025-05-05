using NorthwindDAL.UnitOfWork;

namespace NorthwindApi.Extensions;

public static class ServiceCollection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<INorthwindUnitOfWork, NorthwindUnitOfWork>();     
        services.AddScoped<IRepositoryFactory, RepositoryFactory>();     

        return services;
    }
}
