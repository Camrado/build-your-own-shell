namespace CodeCrafters.Shell.Builtins;

public static class TypeCommand
{
    public static void Execute(string argument)
    {
        if (BuiltinRegistry.IsBuiltin(argument))
        {
            Console.WriteLine($"{argument} is a shell builtin");
        }

        var filePath = FindExecutable(argument);
        if (filePath is not null)
        {
            Console.WriteLine($"{argument} is {filePath}"); 
        }
        else
        {
            Console.WriteLine($"{argument}: not found");
        }
    }

    private static string? FindExecutable(string argument)
    {
        var path = Environment.GetEnvironmentVariable("PATH");
        if (string.IsNullOrEmpty(path))
        {
            return null;
        }
        
        var directories = path.Split(Path.PathSeparator);
        foreach (var directory in directories)
        {
            var fullPath = Path.Combine(directory, argument);
            if (File.Exists(fullPath) && IsExecutable(fullPath))
            {
                return fullPath;
            }
        }

        return null;
    }

    private static bool IsExecutable(string filePath)
    {
        if (!File.Exists(filePath))
            return false;

        return OperatingSystem.IsWindows()
            ? HasExecutableExtensionWindows(filePath)
            : HasUnixExecutePermission(filePath);
    }

    private static bool HasExecutableExtensionWindows(string filePath)
    {
        var pathExt = Environment.GetEnvironmentVariable("PATHEXT");
        var extensions = pathExt?.Split(";") ?? [".COM", ".EXE", ".BAT", ".CMD"];
        
        var fileExtension = Path.GetExtension(filePath);
        
        return extensions.Any(ext => string.Equals(ext, fileExtension, StringComparison.OrdinalIgnoreCase));
    }

    private static bool HasUnixExecutePermission(string filePath)
    {
        var mode = File.GetUnixFileMode(filePath);
        
        return mode.HasFlag(UnixFileMode.UserExecute) ||
               mode.HasFlag(UnixFileMode.GroupExecute) ||
               mode.HasFlag(UnixFileMode.OtherExecute);
    }
}