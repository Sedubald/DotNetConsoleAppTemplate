using CommandLine.Text;
using CommandLine;
using $safeprojectname$.Models;
using $safeprojectname$;
using DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

IHost? host = default;
ILogger<Program>? logger = default;
ParserResult<CommandLineOptions>? options = default;

try
{
    options = Parser.Default.ParseArguments<CommandLineOptions>(args);
    options.Value.Validate();

    host = Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((ctx, builder) =>
        {
            // Register other things like Azure KeyVault
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.AddJsonFile($"appsettings.{options.Value.StagingSystem}.json", optional: false,
                reloadOnChange: true);
        })
        .ConfigureServices((builder, services) =>
        {
            services.AddLogging(c => { c.AddNLog(builder.Configuration); });

            services.AddTransient<App>();
            services.RegisterSettings(builder.Configuration);
            services.RegisterService();

            // You can resolve the registered settings here in case they are needed for the repositories registration
            // var azureSearchSettings = builder.Configuration.GetSection(AzureSearchSettings.SettingsNodeName).Get<AzureSearchSettings>();
            services.RegisterRepositories();
            services.RegisterAutoMapperProfiles();
        })
        .Build();

    logger = host.Services.GetService<ILogger<Program>>();
    options.Value.Validate();

    await host.Services.GetService<App>().RunAsync();
}
catch (InvalidOptionsException paramEx)
{
    Console.WriteLine();
    Console.WriteLine(paramEx.Message);
    Console.WriteLine();
    Console.WriteLine(HelpText.AutoBuild(options, null, null));
}
catch (Exception ex)
{
    logger?.LogError(ex, "Error while application run.");
}
finally
{
    host?.Dispose();
}