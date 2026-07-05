List<string> builtInCommands = ["echo", "type", "exit"];

while (true)
{
    Console.Write("$ ");

    var input = Console.ReadLine();
    if (input == "exit")
    {
        break;
    }
    
    if (input is null)
    {
        continue;
    }

    var command = input.Split(' ', 2);
    
    if (command[0] == "echo")
    {
        Console.WriteLine(command[1]);
    }
    else if (command[0] == "type")
    {
        if (builtInCommands.Contains(command[1]))
        {
            Console.WriteLine($"{command[1]} is a shell builtin");
        }
        else
        {
            Console.WriteLine($"{command[1]}: not found");
        }
    }
    else
    {
        Console.WriteLine($"{input}: command not found");
    }
}