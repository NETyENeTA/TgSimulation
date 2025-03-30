using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgSimultaion;

static class Extentions
{
    public static void Print<T> (this T[] values)
    {
        foreach (T value in values)
        {
            if (value == null)
            {
                Console.WriteLine("Null");
                continue;
            }

            Console.WriteLine(value.ToString());
        }
    }

    public static void Print<T>(this List<T> values)
    {
        foreach (T value in values)
        {
            if (value == null)
            {
                Console.WriteLine("Null");
                continue;
            }

            Console.WriteLine(value.ToString());
        }
    }

    public static T Pop<T> (this List<T> value, int index = 0)
    {
        T result = value[index];
        value.RemoveAt(index);
        return result;
    }

    public static T Random<T> (this T[] values, int? max=null, int? min = null)
    {
        if (!min.HasValue) min = 0;
        if (!max.HasValue) max = values.Length;

        return values[new Random().Next(min.Value, max.Value)];
    }

    public static T Random<T>(this List<T> values, int? max = null, int? min = null)
    {
        if (!min.HasValue) min = 0;
        if (!max.HasValue) max = values.Count;

        return values[new Random().Next(min.Value, max.Value)];
    }

    public static void MultiplicateMe(this string value, int multiplier)
    {
        for (int i = 0; i < multiplier; i++) value += value;
    }

    public static string Multiplicate(this string value, int multiplier)
    {
        string result = "";
        for (int i = 0; i < multiplier; i++) result += value;
        return result;
    }


    public static bool Check(this string value) => value.Any(el => char.IsLetterOrDigit(el));

    /// <summary>
    /// Checks char elements in string.
    /// Example: "Hello, Wolrd!".Check(",!") => true
    /// </summary>
    /// <param name="value"></param>
    /// <param name="includes"></param>
    /// <param name="isFound"></param>
    /// <returns>bool value = if string have char includes...</returns>
    public static bool Check(this string value, string includes, bool isFound = true)
    {
        foreach (char item in includes) if (value.Contains(item)) return isFound;
        return !isFound;
    }

    public static bool Includes(this string value, string[] includes, bool isFound = true)
    {
        foreach (string item in includes) if (value.Contains(item)) return isFound;
        return !isFound;
    }

    public static bool Includes(this string value, int[] includes, bool isFound = true)
    {
        foreach (int item in includes) if (value.Contains(item.ToString())) return isFound;
        return !isFound;
    }


}
