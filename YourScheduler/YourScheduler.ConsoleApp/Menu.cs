using System.ComponentModel;
using YourScheduler.BusinessLogic;

namespace YourScheduler.ConsoleApp
{
    public class Menu
    {
       // private User _usersStore = new User();
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


