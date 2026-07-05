namespace CodeCrafters.Shell.Builtins;

public static class EchoCommand
{
    public static void Execute(string argument)
    {
        Console.WriteLine(argument);
    }
}