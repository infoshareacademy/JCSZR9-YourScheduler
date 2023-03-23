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

        private CliHelper _cliHelper = new CliHelper();
        internal void RunMenu()
        {
            string loggedUser = "marpudlik@wp.pl";
            Console.WriteLine("Witaj! Aplikacja YourScheduler");
            ChooseOperation();

        }

        void ChooseOperation()
        {
            bool exit = false;
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
                        ShowUserProfile();
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
            
            List<User> users = new List<User>();

           
            users = CSVManager.GetUsers();

           
            Console.WriteLine("List of available of users \n");
            foreach (var user in users)
            {
                Console.WriteLine($"users ID: {user.Id}");
                Console.WriteLine($"users Name: {user.Name}");
                Console.WriteLine($"users Surname: {user.Surname}");
                Console.WriteLine();
            }

            string chooseUserToDisplay;

            do
            {
                chooseUserToDisplay = _cliHelper.GetStringFromUser("Get name of user to show profile");
            } while (chooseUserToDisplay=="");
          
            Console.Clear();
           
            User userToDisplay = users.FirstOrDefault(x => x.Name == chooseUserToDisplay);
            if (userToDisplay==null)
            {
                Console.WriteLine("User not found");
                return;
            }

            Console.WriteLine($"Profile of user {userToDisplay.Name}");

            Console.WriteLine($"user ID: {userToDisplay.Id}");
            Console.WriteLine($"user Email: {userToDisplay.Email}");
            Console.WriteLine($"user Password: {userToDisplay.Password}");
            Console.WriteLine($"user Name: {userToDisplay.Name}");
            Console.WriteLine($"user Surname: {userToDisplay.Surname}");
            Console.WriteLine($"user DisplayName: {userToDisplay.DisplayName}");
            Console.WriteLine();

        }

        void ShowTeams()
        {
           
        }

        void ShowEvents()
        {
            List<Event> events = new List<Event>();
            events = CSVManager.GetEvents();

            Console.WriteLine("List of available events: \n");
            foreach (var ev in events)
            {
                Console.WriteLine($"event ID: {ev.Id}");
                Console.WriteLine($"event name: {ev.Name}");
                Console.WriteLine($"event description: {ev.Description}");
                Console.WriteLine($"event date: {ev.Date}");
                foreach (var participantInEventId in ev.Participants)
                {
                    Console.WriteLine($"participant Id: {participantInEventId}");
                }
                Console.WriteLine($"event access: {ev.IsOpen}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}


