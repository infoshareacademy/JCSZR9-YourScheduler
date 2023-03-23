using System.ComponentModel;
using YourScheduler.BusinessLogic;

namespace YourScheduler.ConsoleApp
{
    public class Menu
    {

        private CliHelper _cliHelper = new CliHelper();
        internal void RunMenu()
        {
            Console.WriteLine("Witaj! Aplikacja YourScheduler");
            ChooseOperation();

        }

        void ChooseOperation()
        {
            bool exit = false;
            do
            {
               
                Console.WriteLine("\nWybór operacji:");
                Console.WriteLine("1 - Wyjście");
                Console.WriteLine("2 - Profil użytkownika");
                Console.WriteLine("3 - Zespoły");
                Console.WriteLine("4 - Wydarzenia");
                Console.WriteLine("5 - Dodaj wydarzenie");
                Console.WriteLine("6 - Dodaj użytkownika");
                Console.WriteLine("7 - Edytuj profil użytkownika");


                int operation;
                do
                {
                    operation = _cliHelper.GetIntFromUser("\nWybierz numer operacji: ");
                } while (operation < 0 || operation > 7);

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
                        AddNewUser();
                        break;
                    case 7:
                        UpdateUserProfile();
                        break;

                    default:
                        Console.WriteLine("Zły numer operacji! Wybierz poprawny numer operacji z zakresu 1-7");
                        break;
                }
            } while (!exit);
           
           
           
        }

        void AddNewUser()
        {
            var user = new User(_cliHelper.GetStringFromUser("Podaj imię:"), _cliHelper.GetStringFromUser("Podaj nazwisko:"),
                _cliHelper.GetEmailFromUser("Podaj adres e-mail:"), _cliHelper.GetStringFromUser("Podaj nazwę użytkownika:"),
                _cliHelper.GetSecureStringFromUser("Podaj hasło:"));

            CSVManager.AddNewUser(user);
            Console.WriteLine($"\n\nDodano użytkownika: {user.Name} {user.Surname}");
        }

        void UpdateUserProfile()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("\nEdycja profilu użytkownika:");
                Console.WriteLine("1 - Wyjście");
                Console.WriteLine("2 - Zmiana nazwy użytkownika");
                Console.WriteLine("3 - Zmiana e-mail");
                Console.WriteLine("4 - Zmiana hasła");

                int operation;
                do
                {
                    operation = _cliHelper.GetIntFromUser("\nWybierz numer operacji: ");
                } while (operation < 0 || operation > 4);

                switch (operation)
                {
                    case 1: exit = true;
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    default:
                        Console.WriteLine("Zły numer operacji! Wybierz poprawny numer operacji z zakresu 1-4");
                        break;
                }
            }while(!exit);
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


