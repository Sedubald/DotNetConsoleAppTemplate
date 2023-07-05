namespace DI;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class SettingsConfiguration
{
    public static void RegisterSettings(this IServiceCollection services, IConfiguration config)
    {
        // Example configuration for a setting, the SettingsNodeName is a property which contains the node name of the setting.
        // services.Configure<AzureSearchSettings>(config.GetSection(AzureSearchSettings.SettingsNodeName));
    }
}
