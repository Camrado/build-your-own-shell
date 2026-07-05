class Program
{
    static void Main()
    {
        Console.Write("$ ");
        
        var input = Console.ReadLine();
        Console.WriteLine($"{input}: command not found");
    }
}
