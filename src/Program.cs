while (true)
{
    Console.Write("$ ");

    var input = Console.ReadLine();
    if (input == "exit")
    {
        break;
    }
    
    Console.WriteLine($"{input}: command not found");
}