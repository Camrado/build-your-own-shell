using CodeCrafters.Shell.Utils;

namespace CodeCrafters.Shell.Builtins;

public static class TypeCommand
{
    public static void Execute(string argument)
    {
        if (BuiltinRegistry.IsBuiltin(argument))
        {
            Console.WriteLine($"{argument} is a shell builtin");
            return;
        }

        var filePath = PathResolver.FindExecutableFromPath(argument);
        Console.WriteLine(filePath is not null ? $"{argument} is {filePath}" : $"{argument}: not found");
    }
}