using System.ComponentModel;
using System.Linq.Expressions;
using YourScheduler.BusinessLogic;

namespace YourScheduler.ConsoleApp
{
    public class Menu
    { 

        {
            _currentUser = new User("Marcin", "Dylowicz", "mar@test.com", "marcin77", "password321");
            CSVManager.AddNewUser(_currentUser);
        }
            WelcomeScreen(); 
        {
            _currentUser = new User("Marcin", "Dylowicz", "mar@test.com", "marcin77", "password321");
            CSVManager.AddNewUser(_currentUser);
        }
            Console.WriteLine("Witaj! Aplikacja YourScheduler");
            ChooseOperation(); 
        {
            _currentUser = new User("Marcin", "Dylowicz", "mar@test.com", "marcin77", "password321");
            CSVManager.AddNewUser(_currentUser);
        }

        private readonly User _currentUser;
        {
            _currentUser = new User("Marcin", "Dylowicz", "mar@test.com", "marcin77", "password321");
            CSVManager.AddNewUser(_currentUser);
        }

        private readonly User _currentUser;
        private CliHelper _cliHelper = new CliHelper();
        private UserService _userService = new UserService();
        internal void RunMenu()
        {
            Console.WriteLine("Witaj! Aplikacja YourScheduler");
            ChooseOperation(); 
        }

        void ChooseOperation(User user)
        {
            bool exit=false;
            do
            {
                Console.WriteLine($"Zalogowano jako: {user.Name} {user.Surname}");
               
                Console.WriteLine("Choose operation");
                Console.WriteLine("1 - exit");
                Console.WriteLine("2 - Show User Profile");
                        ShowUserProfile();
                Console.WriteLine("4 - Show Events");
                Console.WriteLine("5 - Add Event");
                Console.WriteLine("6 - Add User");


                int operation;
                do
                {
                    operation = _cliHelper.GetIntFromUser("Write number choosen operation 1-exit,2, 3, 4, 5, 6");
                } while (operation < 0 || operation > 6);

                    case 7:
                        UpdateUserProfile(user);
                        break;
                        exit = true;
                        break;
                    case 2:
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
                    case 7:
                        UpdateUserProfile();
                        break;

                    default:
                        Console.WriteLine("You get wrong number operation");
                        break;
                }
            } while (!exit);
           
           
           
        }
        void WelcomeScreen()
        {
            bool exit = false;
            int operation;
            Console.WriteLine("_____.___.                       _________      .__               .___    .__                \r\n\\__  |   | ____  __ _________   /   _____/ ____ |  |__   ____   __| _/_ __|  |   ___________ \r\n /   |   |/  _ \\|  |  \\_  __ \\  \\_____  \\_/ ___\\|  |  \\_/ __ \\ / __ |  |  \\  | _/ __ \\_  __ \\\r\n \\____   (  <_> )  |  /|  | \\/  /        \\  \\___|   Y  \\  ___// /_/ |  |  /  |_\\  ___/|  | \\/\r\n / ______|\\____/|____/ |__|    /_______  /\\___  >___|  /\\___  >____ |____/|____/\\___  >__|   \r\n \\/                                    \\/     \\/     \\/     \\/     \\/               \\/       ");
            Console.WriteLine("1. Zaloguj się");
            Console.WriteLine("2. Zarejestruj się");
            Console.WriteLine("3. Zakończ działanie");
            do
            {
                operation = _cliHelper.GetIntFromUser("\nWybierz numer operacji: ");
            } while (operation < 0 || operation > 3);

            switch (operation)
            {
                case 1:
                    ChooseTestUser();
                    break;
                case 2:
                    AddNewUser();
                    Console.Clear();
                    WelcomeScreen();
                    break;
                case 3:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Niepoprawny wybór!");
                    break;

            } while (!exit) ;

        }
        void ChooseTestUser()
        {
            Console.Clear();
            Console.WriteLine("Lista użytkowników:");
            int operation;
            int index = 1;
            ChooseOperation(_userService.userList[operation - 1]);

        }
        void AddNewUser()
            {
                Console.WriteLine($"{index}. {user.Name} {user.Surname}");
                index++;
            }
            do
            {
                operation = _cliHelper.GetIntFromUser("\nWybierz numer użytkownika: ");
                if (operation < 0 || operation > _userService.userList.Count())
                {
                    Console.WriteLine("Niepoprawny wybór!");
                }
                else
                {
                    break;
                }
            _userService.AddNewUser(user);
            Console.WriteLine($"\n\nDodano użytkownika: {user.Name} {user.Surname}");
        }

        void UpdateUserProfile(User user)
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
                    case 1: 
                        exit = true;
                        break;

                    case 2:
                        UpdateUserDisplayName(user);
                        break;

                    case 3:
                        UpdateUserEmail(user);
                        break;

                    case 4:
                        UpdateUserPassword(user);
                        break;

                    default:
                        Console.WriteLine("Zły numer operacji! Wybierz poprawny numer operacji z zakresu 1-4");
                        break;
                }
            }while(!exit);
        }


        void UpdateUserDisplayName(User user)
        {
            _userService.UpdateUserDisplayName(user.Id, _cliHelper.GetStringFromUser("Podaj nową nazwę użytkownika: "));
            Console.WriteLine($"\nZmieniono nazwę użytkownika {user.Name} {user.Surname}");
        }
        void UpdateUserEmail(User user)
        {
            _userService.UpdateUserEmail(user.Id, _cliHelper.GetEmailFromUser("Podaj nowy email: "));
            Console.WriteLine($"\nZmieniono email użytkownika {user.Name} {user.Surname}");
        }

        void UpdateUserPassword(User user)
        {
            _userService.UpdateUserPassword(user.Id, _cliHelper.GetSecureStringFromUser("Podaj nowe hasło: "));
            Console.WriteLine($"\nZmieniono hasło użytkownika {user.Name} {user.Surname}");
        }

        void ShowUserProfile()
        {
            Console.WriteLine($"Imię: {_currentUser.Name}");
            Console.WriteLine($"Nazwisko: {_currentUser.Surname}");
            Console.WriteLine($"Nazwa użytkownika: {_currentUser.DisplayName}");
            Console.WriteLine($"Email: {_currentUser.Email}");
        void UpdateUserEmail()
        {
            CSVManager.UpdateUserEmail(_currentUser.Id, _cliHelper.GetEmailFromUser("Podaj nowy email: "));
            Console.WriteLine($"\nZmieniono email użytkownika {_currentUser.Name} {_currentUser.Surname}");
        }

        void UpdateUserPassword()
        {
            CSVManager.UpdateUserPassword(_currentUser.Id, _cliHelper.GetSecureStringFromUser("Podaj nowe hasło: "));
            Console.WriteLine($"\nZmieniono hasło użytkownika {_currentUser.Name} {_currentUser.Surname}");
        }

        void ShowUserProfile()
        {
            Console.WriteLine($"Imię: {_currentUser.Name}");
            Console.WriteLine($"Nazwisko: {_currentUser.Surname}");
            Console.WriteLine($"Nazwa użytkownika: {_currentUser.DisplayName}");
            Console.WriteLine($"Email: {_currentUser.Email}");
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


