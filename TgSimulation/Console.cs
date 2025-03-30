using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TgSimultaion;

public class MyConsole
{
    // just a delegate
    delegate bool DUser(User user);

    /// <summary>
    /// Checks user.Name, if it has any numbers.
    /// </summary>
    /// <param name="user">It's just a user!</param>
    /// <returns>so, it return true, else false</returns>
    static bool NameWithoutNumbers(User user) => user.Name.Includes([0, 1, 2, 3, 4, 5, 6, 7, 8, 9]);

    /// <summary>
    /// Checks user.Name, if it has any spaces like this "My Name".
    /// </summary>
    /// <param name="user">It's just a user!</param>
    /// <returns>so, it return true, else false</returns>
    static bool SpaceInName(User user) => user.Name.Contains(' ');

    /// <summary>
    /// Checks user.Name, if it has any special symbols like this "#My!Name{}Is|Adrian".
    /// </summary>
    /// <param name="user">It's just a user!</param>
    /// <returns>so, it return true, else false</returns>
    static bool NameWithoutSpecialSymbols(User user) => user.Name.Check(".,:/\\|[]{}()'\"!?@#$%^&*№%");

    /// <summary>
    /// Checks user.Age, if it bigger than 18.
    /// </summary>
    /// <param name="user">It's just a user!</param>
    /// <returns>so, it return true, else false</returns>
    static bool UserIsAdult(User user) => user.Age >= User.DefaultAge;

    /// <summary>
    /// It's just a event Action, yup it is private!
    /// </summary>
    event Action OnUserCreated = delegate { };

    /// <summary>
    /// Just checks user.Name by delegates and user.Age by "if"
    /// and if user is adult (grate 18), so he/she will be written here in file "users.txt"
    /// </summary>
    /// <param name="user">It's just a user!</param>
    /// <exception cref="ErrorWithName">If name has incorrect format, so you can catch an error, or errors :)</exception>
    public void Run(User user)
    {
        DUser[] checks = [NameWithoutNumbers, SpaceInName, NameWithoutSpecialSymbols];


        // It would have been possible to add separate checks and assign an error to each of them, but I chose the general one -invalid username.
        foreach (DUser check in checks) if (check(user)) throw new ErrorWithName("\nPlease retype a name without special symbols.");


        OnUserCreated += () =>
        {
            Console.WriteLine($"User ({user.Name}-{user.Age}) was created!");


            if (UserIsAdult(user))
            {
                Console.WriteLine("Current user is adult, writing to file: \"users.txt\"");
                FileManager.Write("users.txt", user.ToString(), true);
            }
            else Console.WriteLine("Current user is child!!!");

        };
    }

    /// <summary>
    /// Starts action "OnUserCreated".
    /// </summary>
    public void Start() => OnUserCreated();

}
