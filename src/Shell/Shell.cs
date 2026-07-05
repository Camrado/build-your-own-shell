using CodeCrafters.Shell.Builtins;

namespace CodeCrafters.Shell.Shell;

public sealed class Shell
{
    public void Run()
    {
        while (true)
        {
            Console.Write("$ ");

            var input = Console.ReadLine();
            if (input is null)
            {
                break;
            }
            
            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }
            
            var parts = input.Split(' ', 2);
            var command = parts[0];
            var argument = parts.Length > 1 ? parts[1] : string.Empty;
            
            Dispatch(command, argument, input);
        }
    }

    private void Dispatch(string command, string argument, string rawInput)
    {
        switch (command)
        {
            case "exit":
                Environment.Exit(0);
                break;

            case "echo":
                EchoCommand.Execute(argument);
                break;

            case "type":
                TypeCommand.Execute(argument);
                break;

            default:
                ExternalCommandRunner.ExecuteExternalProgram(command, argument, rawInput);
                break;
        }
    }
}