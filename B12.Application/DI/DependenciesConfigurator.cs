namespace B12.Application.DI;

using B12.Application.MappingProfile;

public static class DependenciesConfigurator
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.ConfigureAutoMapper();
    }

    private static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductProfile).Assembly);
        services.AddAutoMapper(typeof(CategoryProfile).Assembly);
        services.AddAutoMapper(typeof(TagProfile).Assembly);
    }
}