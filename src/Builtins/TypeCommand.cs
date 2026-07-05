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
            if (File.Exists(fullPath))
            {
                return fullPath;
            }
        }

        return null;
    }
}