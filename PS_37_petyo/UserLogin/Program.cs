using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        static void DisplayError(string errorMessage)
        {
            Console.WriteLine("!!! " + errorMessage + " !!!");
        }

        static void ShowAdministratorMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Select option:");
                Console.WriteLine("0: exit");
                Console.WriteLine("1: Update user role");
                Console.WriteLine("2: update user activity");
                Console.WriteLine("3: List of users");
                Console.WriteLine("4: Show log activity");
                Console.WriteLine("5: Show current activity");

                int option;

                if (!int.TryParse(Console.ReadLine(), out option) || option < 0 || option > 5)
                {
                    Console.WriteLine("Please select option!");
                    continue;
                }

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Exit...");
                        return;
                    case 1:
                        ChangeUserRole();
                        break;
                    case 2:
                        ChangeUserActiveTo();
                        break;
                    case 3:
                        foreach (var user in UserData.TestUsers)
                            Console.WriteLine(user.ToString());
                        break;
                    case 4:
                        StreamReader reader = new StreamReader(Logger.FileName);
                        Console.WriteLine(reader.ReadToEnd());
                        reader.Close();
                        break;
                    case 5:
                        Console.WriteLine(Logger.GetCurrentSessionActivities());
                        break;
                }
            }
        }

        static void ChangeUserRole()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Roles: 0-ANONYMOUS, 1-ADMIN, 2-INSPECTOR, 3-PROFESSOR, 4-STUDENT");
            Console.Write("Enter new role:");
            int role;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out role) || role < 0 || role > 4)
                {
                    Console.WriteLine("Please select again!");
                    continue;
                }
                else
                    break;
            }

            
            UserData.AssignUserRole(UserData.TestUsers
                .Where(user => user.Username.Equals(user))
                .First().UserId, (UserRoles) role);
        }

        static void ChangeUserActiveTo()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Eneter new date ");
            DateTime activeTo;
            while (true)
            {
                if (!DateTime.TryParse(Console.ReadLine(), out activeTo))
                {
                    Console.WriteLine("Please enter again!");
                    continue;
                }
                else
                    break;
            }

            UserData.SetUserActiveTo(username, activeTo);
        }

        static void Main(string[] args)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password ");
            string password = Console.ReadLine();
            var validation = new LoginValidation(username, password, DisplayError);
            User user = null;
            if (validation.ValidateUserInput(ref user))
            {
                Console.WriteLine("Username:" + user);
                Console.Write("Role: ");
                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("ANONYMOUS");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("ADMIN");
                        ShowAdministratorMenu();
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("INSPECTOR");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("PROFESSOR");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("STUDEN");
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}