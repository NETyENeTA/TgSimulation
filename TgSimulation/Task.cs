using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TgSimultaion;

namespace TgSimulation;

public class MyTask
{
    static int _ID = 0;
    static bool IsInitialized = false;

    public int ID { get; private set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public Time Time { get; set; }


    public static void Init(int id)
    {
        _ID = id;
        IsInitialized = true;
    }

    public MyTask(string[] args)
    {
        if (!IsInitialized) throw new InitialiazationError(this.GetType().Name);
        ID = Interlocked.Increment(ref _ID);

        if (args.Length < 3) throw new Exception("Error with Length, Task need 3 args!!!");

        Title = args[0];
        Body = args[1];
        Time = new(args[2]);
    }

    public MyTask(string title, string body, string time)
    {
        if (!IsInitialized) throw new InitialiazationError(this.GetType().Name);
        ID = Interlocked.Increment(ref _ID);

        Title = title;
        Body = body;
        Time = new(time);
    }
    public override string ToString() => $"----------------\nID:{ID}\nTittle:{Title}\nBody:\n{Body}\nAt {Time.ToString()}";
}

public class Tasks
{
    public List<MyTask> Values { get; private set; } = [];

    public bool IsOn = true;

    public bool IsEmpty
    {
        get
        {
            return Values.Count == 0;
        }
    }

    public Tasks()
    {
        Thread thread = new(Checking);
        IsOn = true;
        thread.Start();
    }

    void Checking()
    {
        List<MyTask> tasks = [];

        while (IsOn)
        {
            Thread.Sleep(1000);
            foreach (MyTask task in new List<MyTask>(Values))
                if (task.Time == Time.Now) tasks.Add(task);

            if (tasks.Count != 0)
            {
                Console.Clear();

                foreach (MyTask task in tasks) Console.WriteLine($"?!Notification?!:{task.ToString()}\n----------------");
                
                tasks.Clear();
                Console.Write("..Terminal>>");
            }
        }
    }

    public void Add(MyTask task) => Values.Add(task);
    public void Add(string task, string separator = ".") => Values.Add(new(task.Split(separator)));
    public MyTask? Get(Func<MyTask, bool> function) => Values.FirstOrDefault(function);
    public void Remove(MyTask task) => Values.Remove(task);
    public void Remove(int id) => Values = Values.Where(t => t.ID != id).ToList();
    public void RemoveAt(int id) => Values.RemoveAt(id);
}
