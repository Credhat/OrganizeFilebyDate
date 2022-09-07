namespace Study01;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine($"Pls input your name & birthday:\t");
        string nameAndBirthday=Console.ReadLine().ToString();
        Console.WriteLine("Your Name and Birthday:\t{0}",nameAndBirthday);
        Console.WriteLine("Pls press Enter to exit…………");
        while(Console.ReadKey().Key!=ConsoleKey.Enter){}
    }
}
