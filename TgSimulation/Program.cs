using TgSimulation;

namespace TgSimultaion;


class Program
{

    static void Main(string[] agrs)
    {
        Console.WriteLine("Hello, world!");

        //Console.Write("Type Name:");
        //string? name = Console.ReadLine();
        //if (name == null) throw new ConsoleReadLineError("\nIt Just a error in the console, don't worry about it (maybe mistake was with a name) :)");

        //Console.Write("Now, type an age:");
        //if (!int.TryParse(Console.ReadLine(), out int age)) throw new IntParseError("\n Or it will happen again");

        //MyConsole console = new();
        //console.Run(new(name, age));
        //console.Start();

        MyTask.Init(-1);

        Terminal.Run();

        // Stops Console, else it will close itself :>
        Console.ReadLine();
    }
}