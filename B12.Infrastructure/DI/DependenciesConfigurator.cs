namespace B12.Infrastructure.DI;

using B12.Infrastructure.Repositories;
using B12.Domain.Interfaces;

public static class DependenciesConfigurator
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediator();
        services.AddServices();
        services.AddDataBaseServices(configuration);
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
    }

    private static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        });
    }

    private static void AddDataBaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<B12DbContext>(options =>
            options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
    }
}