namespace $safeprojectname$.Models;

internal class InvalidOptionsException : Exception
{
    public InvalidOptionsException(string paramName, string value) : base($"Value {value} is not valid for option {paramName}.")
    {

    }
}
