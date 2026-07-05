using System.Diagnostics;
using CodeCrafters.Shell.Utils;

namespace CodeCrafters.Shell.Shell;

public static class ExternalCommandRunner
{
    public static void ExecuteExternalProgram(string command, string arguments, string rawInput)
    {
        var filePath = PathResolver.FindExecutable(command);
        if (filePath is null)
        {
            Console.WriteLine($"{rawInput}: command not found");
        }
        
        var startInfo = new ProcessStartInfo
        {
            FileName = filePath,
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