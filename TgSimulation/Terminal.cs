using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TgSimultaion;

namespace TgSimulation;


static class Commands
{

    public static Dictionary<string, int> English = new() {
        {"add", 0},
        {"ad", 0},
        {"a", 0},
        {"dd", 0},

        {"list", 1},
        {"ls", 1},
        {"lst", 1},
        {"l", 1},

        {"delete", 2},
        {"del", 2},
        {"dele", 2},
        {"d", 2},

        {"help", 3},
        {"hlp", 3},
        {"hp", 3},
        {"h", 3},

        {"exit", 4},
        {"exi", 4},
        {"ex", 4},
        {"e", 4},
    };

    public static Dictionary<int, string> Helps = new()
    {
        {0, "Add new task to bot" },
        {1, "get task's list" },
        {2, "delete task" },
        {3, "help,\ntry: 'help <command>'" },
        {4, "exit" },
    };

    public const int Add = 0;
    public const int List = 1;
    public const int Delete = 2;
    public const int Help = 3;
    public const int Exit = 4;
}

class Command
{
    public static bool isNeedLower = true;

    public string value = "";
    public List<string> args = [];

    public int Lenght
    {
        get
        {
            return args.Count;
        }
    }

    public bool IsEmpty
    {
        get
        {
            return value == String.Empty;
        }
    }

    public Command(string? line, string? separator = null)
    {
        if (SetArgs(line, separator)) return;
        if (isNeedLower) line = line.ToLower();


        value = args.Pop();
    }

    public bool SetArgs(string? line, string? separator = null)
    {
        if (line == null) return true;
        args = [.. (separator == null ? line.Split() : line.Split(separator))];
        return false;
    }

}

public class Terminal
{

    static readonly string[] Smiles = ";> :/ :O xD".Split();

    static readonly string Path = "saves/datebase.json";

    static Tasks Load(string path = "datebase.json")
    {
        Tasks? tasks = JsonManager<Tasks>.Read(path);

        if (tasks == null) return new();
        return tasks;
    }

    public static void Run()
    {
        Tasks tasks = Load(Path);
        int value;

        while (true)
        {
            Console.Write("\n...Terminal>>");
            Command command = new(Console.ReadLine());

            if (command.IsEmpty)
            {
                Console.WriteLine("Empty Command!\nTry Help");
                continue;
            }

            if (!Commands.English.TryGetValue(command.value, out value)) {

                Console.WriteLine("Wrong Command!\nTry Help");
                continue;
            }


            switch (value)
            {

                case Commands.Help:
                    int old = -1;
                    foreach (KeyValuePair<string, int> pair in Commands.English.ToArray())
                    {
                        if (old != pair.Value)
                        {
                            old = pair.Value;
                            Console.WriteLine($"\n{"----------------------------"}\n");
                        }
                        if (Commands.Helps.TryGetValue(pair.Value, out string? help)) Console.WriteLine($"[{pair.Key.ToUpper()}]: {$"{help} {(old == 4 || Time.Now.Milleseconds == 16_840_000 ? Smiles.Random() : "")}"}");
                    }
                    break;

                case Commands.Exit:
                    tasks.IsOn = false;
                    Console.WriteLine($"Thanks for use\nall is saved into the file, path:{Path}");
                    return;

                case Commands.Add:

                    if (command.Lenght == 0)
                    {
                        Console.WriteLine("Please type into format:\"title.body.HH:MM:SS\"");
                        command.SetArgs(Console.ReadLine());
                    }

                    foreach (string arg in command.args)
                    {
                        try
                        {
                            tasks.Add(arg);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Wrong Format");
                            //Console.WriteLine(ex);
                        }
                    }



                    break;

                case Commands.Delete:

                    if (command.Lenght == 0)
                    {
                        Console.WriteLine("Please type id");
                        command.SetArgs(Console.ReadLine());
                    }

                    foreach (string arg in command.args)
                    {
                        if (!int.TryParse(arg, out value))
                        {
                            Console.WriteLine("It's not int!!!");
                            continue;
                        }

                        tasks.Remove(value);
                    }
                    break;

                case Commands.List:

                    if (tasks.IsEmpty)
                    {
                        Console.WriteLine("List is empty for this account!");
                        return;
                    }

                    Console.WriteLine("List:");
                    tasks.Values.Print();
                    Console.WriteLine("----------------");
                    break;

                default:
                    // somthing next feature
                    Console.WriteLine("Somthing in new update was appear :>\nlet's wait it ;)");
                    break;
            }

        }
    }



}
