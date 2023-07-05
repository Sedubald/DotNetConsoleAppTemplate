namespace ConsoleTemplate;

using Microsoft.Extensions.Logging;

public class App
{
    private readonly ILogger<App> _logger;

    public App(ILogger<App> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task RunAsync()
    {
        _logger.LogInformation("[Start] Application started.");

        // TODO: Add application stuff

        _logger.LogInformation("[End] Application ended.");
    }
}