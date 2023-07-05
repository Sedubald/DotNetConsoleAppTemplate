namespace ConsoleTemplate.Models;

using CommandLine;

public class CommandLineOptions
{
    [Option('s', "staging", Required = true, HelpText = "Target staging system. Options: development, uat, production")]
    public string StagingSystem { get; set; } = string.Empty;

    public void Validate()
    {
        if (!StagingSystem.Equals("development") &&
            !StagingSystem.Equals("uat") &&
            !StagingSystem.Equals("production"))
        {
            throw new InvalidOptionsException("staging", StagingSystem);
        }
    }
}