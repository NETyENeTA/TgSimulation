using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgSimultaion;

public class User
{

    public static int DefaultAge { get; private set; } = 18;

    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }


    public User(string name, int? age = null)
    {
        Name = name;
        Age = age ?? DefaultAge;
    }

    public int SetDefaultAge(int age) => DefaultAge = age;

    public override string ToString() => $"Class:User;\nName:{Name};\nAge:{Age};\n\n";
}
