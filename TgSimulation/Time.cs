using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TgSimultaion;

namespace TgSimulation;

public class Time
{

    int Second;
    int Minute;
    int Hour;

    public int Seconds
    {
        get { return Second; }
        set { Second = value % 60; }
    }
    public int Minutes
    {
        get { return Minute; }
        set { Minute = value % 60; }
    }
    public int Hours
    {
        get { return Hour; }
        set { Hour = value % 24; }
    }

    public static Time Now
    {
        get
        {
            return new Time(DateTime.Now);
        }
    }

    public int Milleseconds
    {
        get
        {
            return Second * 1000 + Minute * 60_000 + Hour * 3_600_000;
        }
    }

    public Time(int seconds, int minutes, int hours)
    {
        Seconds = seconds;
        Minutes = minutes;
        Hours = hours;
    }

    public Time(DateTime dateTime)
    {
        Seconds = dateTime.Second;
        Minutes = dateTime.Minute;
        Hours = dateTime.Hour;
    }

    public Time(string time)
    {
        DateTime dateTime = DateTime.Parse(time);

        Seconds = dateTime.Second;
        Minutes = dateTime.Minute;
        Hours = dateTime.Hour;
    }

    public static bool operator ==(Time time, Time time1) => time.Second == time1.Second && time.Minute == time1.Minute && time.Hour == time1.Hour;
    public static bool operator !=(Time time, Time time1) => !(time == time1);

    public string ToString(string format = "%h%:%m%:%s%") => format.ToLower()
        .Replace("%h%", Hours.ToString())
        .Replace("%m%", Minutes.ToString())
        .Replace("%s%", Seconds.ToString());


}
