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
    else
    {
        Console.WriteLine($"{input}: command not found");
    }
}