using System.Diagnostics;
using CodeCrafters.Shell.Utils;

namespace CodeCrafters.Shell.Shell;

public static class ExternalCommandRunner
{
    public static void ExecuteExternalProgram(string command, string arguments, string rawInput)
    {
        var filePath = PathResolver.FindExecutableFromPath(command);
        if (filePath is null)
        {
            Console.WriteLine($"{rawInput}: command not found");
            return;
        }
        
        var startInfo = new ProcessStartInfo
        {
            FileName = command,
            Arguments = arguments,
            UseShellExecute = false,
            RedirectStandardOutput = false,
            RedirectStandardError = false,
            RedirectStandardInput = false
        };
        
        using var process = Process.Start(startInfo);
        process?.WaitForExit();
    }
}