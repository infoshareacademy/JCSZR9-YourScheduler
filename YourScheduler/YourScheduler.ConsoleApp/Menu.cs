using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic;

namespace YourScheduler.ConsoleApp
{
    public class Menu
    {
       // private User _usersStore = new User();
        private CliHelper _cliHelper = new CliHelper();
        internal void RunMenu()
        {
            string loggedUser = "marpudlik@wp.pl";
            Console.WriteLine("Witaj! Aplikacja YourScheduler");

            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine($"Podaj {i + 1} user");
            //    UserTemporary user = new UserTemporary
            //    {
            //        Id = i + 1,
            //        Name = _cliHelper.GetStringFromUser("Get name of User"),
            //        Surname = _cliHelper.GetStringFromUser("Get surname of User"),
            //        Email = _cliHelper.GetStringFromUser("Get email"),
            //        Password = _cliHelper.GetStringFromUser("Password")
            //    };

            //    _usersStore.users.Add(user);
            //}

            Console.WriteLine("Choose operation");
            Console.WriteLine("1 - Show User Profile");
            Console.WriteLine("2 - Show Teams");
            Console.WriteLine("3 - Show Events");
            Console.WriteLine("4 - Add Event");
            Console.WriteLine("5 - Add User");
            ChooseOperation(loggedUser);
        }

        void ChooseOperation(string loggedUser)
        {
            int operation;
            do
            {
                operation = _cliHelper.GetIntFromUser("Choose number of operation 1, 2, 3, 4, 5");
            } while (operation <= 0 || operation > 5);

            switch (operation)
            {
                case 1:
                    ShowUserProfile(loggedUser);
                    break;
                case 2:
                    ShowTeams();
                    break;
                case 3:
                    ShowEvents();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("You get wrong number operation");
                    break;
            }
        }

        void ShowUserProfile(string loggedUser)
        {
            //bool ifUserExist = false;
            //foreach (var user in _usersStore.users)
            //{
            //    if (loggedUser == user.Email)
            //    {
            //        ifUserExist = true;
            //        Console.WriteLine("It is profil logged user: ");
            //        Console.Write($"{user.Name}");
            //        Console.WriteLine($"{user.Surname}");
            //        Console.WriteLine($"{user.Email}");
            //        Console.WriteLine($"{user.Password}");
            //        return;
            //    }

            //}
            //if (ifUserExist == false)
            //{
            //    Console.WriteLine($"User {loggedUser} Doesn't exist");
            //}

        }

        void ShowTeams()
        {
            //foreach (var item in collection)
            //{

            //}
        }

        void ShowEvents()
        {
            //foreach (var item in collection)
            //{

            //}

        }
    }
}


