using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgSimultaion;


public class ErrorInPeriod : Exception
{
    public ErrorInPeriod(string message = "") : base("Error in Period;\nstring[] massive = [el0, el1, el2];\nmassive.GiveMe(From=0, to=5);\nWhere are el with indexes 3 4 5???" + message) { }
}

public class WrongType : Exception
{
    /// <summary>
    /// Exception with Type of object from inited class
    /// </summary>
    /// <param name="name">Type name</param>
    public WrongType(string name) : base("Wrong type! Needs:" + name) { }
}

public class ErrorWithName : Exception
{
    public ErrorWithName(string message = "") : base("Error in the name!" + message) { }
}

public class ConsoleReadLineError : Exception
{
    public ConsoleReadLineError(string message = "") : base("The console was closed, maybe it was a error or mistake" + message) { }
}

public class IntParseError : Exception
{
    public IntParseError(string message = "") : base("Please type a NUMBER, not string" + message) { }
}

public class InitialiazationError : Exception
{
    /// <summary>
    /// Wrong with not yet initiliazed class, pls use Class.Init() it is static method
    /// </summary>
    /// <param name="name"></param>
    public InitialiazationError(string name) : base($"Please use {name}.Init()") { }
}

// And here it would have been possible to describe the remaining exceptions, but alas, the terms of reference do not require this)
