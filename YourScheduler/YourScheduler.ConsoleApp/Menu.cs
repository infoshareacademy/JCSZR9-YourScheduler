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
            ChooseOperation(); 
          
        }

        void ChooseOperation()
        {
            bool exit=false;
            do
            {
               
                Console.WriteLine("Choose operation");
                Console.WriteLine("1 - exit");
                Console.WriteLine("2 - Show User Profile");
                Console.WriteLine("3 - Show Teams");
                Console.WriteLine("4 - Show Events");
                Console.WriteLine("5 - Add Event");
                Console.WriteLine("6 - Add User");


                int operation;
                do
                {
                    operation = _cliHelper.GetIntFromUser("Write number choosen operation 1-exit,2, 3, 4, 5, 6");
                } while (operation < 0 || operation > 6);

                switch (operation)
                {
                    case 1:
                        exit = true;
                        break;
                    case 2:
                        Console.WriteLine("hej");
                        //ShowUserProfile(loggedUser);
                        break;
                    case 3:
                        ShowTeams();
                        break;
                    case 4:
                        ShowEvents();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;

                    default:
                        Console.WriteLine("You get wrong number operation");
                        break;
                }
            } while (!exit);
           
           
           
        }

        void ShowUserProfile()
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


