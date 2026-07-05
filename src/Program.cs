while (true)
{
    Console.Write("$ ");

    var input = Console.ReadLine();
    if (input == "exit")
    {
        break;
    }
    
    if (input == "echo")
    {
        Console.WriteLine(input);
    }
    else
    {
        Console.WriteLine($"{input}: command not found");
    }
}