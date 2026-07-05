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

    var command = input.Split(' ')[0];
    if (command == "echo")
    {
        Console.WriteLine(input);
    }
    else
    {
        Console.WriteLine($"{input}: command not found");
    }
}