namespace CodeCrafters.Shell.Builtins;

public static class BuiltinRegistry
{
    public static readonly List<string> Names = ["echo", "type", "exit"];

    public static bool IsBuiltin(string command) => Names.Contains(command);
}