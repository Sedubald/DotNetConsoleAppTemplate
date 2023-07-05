namespace $safeprojectname$;

using Microsoft.Extensions.DependencyInjection;

public static class RepositoriesConfiguration
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        // TODO: Register repositories
    }

    public static void RegisterAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            // TODO: Register profiles
            //config.AddProfile<ExampleProfile>();
        });
    }
}
