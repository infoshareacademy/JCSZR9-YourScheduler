using System.ComponentModel;
using YourScheduler.BusinessLogic;

namespace YourScheduler.ConsoleApp
{
    public class Menu
    {
        public Menu() 
        {
            _currentUser = new User("Marcin", "Dylowicz", "mar@test.com", "marcin77", "password321");
            CSVManager.AddNewUser(_currentUser);
        }

        private readonly User _currentUser;
        private CliHelper _cliHelper = new CliHelper();
        internal void RunMenu()
        {
            Console.WriteLine("Witaj! Aplikacja YourScheduler");
            ChooseOperation(); 
        }

        void ChooseOperation()
        {
            bool exit=false;
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
                    case 1: 
                        exit = true;
                        break;

                    case 2:
                        UpdateUserDisplayName();
                        break;

                    case 3:
                        UpdateUserEmail();
                        break;

                    case 4:
                        UpdateUserPassword();
                        break;

                    default:
                        Console.WriteLine("Zły numer operacji! Wybierz poprawny numer operacji z zakresu 1-4");
                        break;
                }
            }while(!exit);
        }


        void UpdateUserDisplayName()
        {
            CSVManager.UpdateUserDisplayName(_currentUser.Id, _cliHelper.GetStringFromUser("Podaj nową nazwę użytkownika: "));
            Console.WriteLine($"\nZmieniono nazwę użytkownika {_currentUser.Name} {_currentUser.Surname}");
        }
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


