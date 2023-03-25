using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using YourScheduler.BusinessLogic;

namespace YourScheduler.ConsoleApp
{
    public class Menu
    {
        private CliHelper _cliHelper = new CliHelper();
        private UserService _userService = new UserService();

        internal void RunMenu()
        {
            WelcomeScreen();

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
                    exit = true;
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
        void AddNewUser()
        {
            User newUser = new User(_cliHelper.GetStringFromUser("Podaj imię użytkownika"),
                _cliHelper.GetStringFromUser("Podaj nazwisko użytkownika"),
                _cliHelper.GetEmailFromUser("Podaj e-mail użytkownika"),
                _cliHelper.GetStringFromUser("Podaj login użytkownika"),
                _cliHelper.GetSecureStringFromUser("Podaj hasło użytkownika"));
            _userService.AddNewUser(newUser);
            CSVManager.UpdateUsers(_userService.userList);
        }
        void ChooseTestUser()
        {
            Console.Clear();
            Console.WriteLine("Lista użytkowników:");

            int operation;
            int index = 1;

            foreach (User user in _userService.userList)
            {
                Console.WriteLine($"{index}. {user.DisplayName} - {user.Name} {user.Surname}");
                index++;
            }
            while (true)
            {
                operation = _cliHelper.GetIntFromUser("Wybierz numer użytkownika");
                try
                {
                    ChooseOperation(_userService.userList[operation - 1]);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Podany numer jest nieprawidłowy!");
                    Console.Clear();
                    ChooseTestUser();
                }
            }

            

        }
        void UpdateUserDisplayName(User user)
        {
            _userService.UpdateUserDisplayName(user.Id, _cliHelper.GetStringFromUser("Podaj nową nazwę użytkownika: "));
            Console.WriteLine($"\nZmieniono nazwę użytkownika {user.Name} {user.Surname}");
            CSVManager.UpdateUsers(_userService.userList);
        }
        void UpdateUserEmail(User user)
        {
            _userService.UpdateUserEmail(user.Id, _cliHelper.GetEmailFromUser("Podaj nowy email: "));
            Console.WriteLine($"\nZmieniono email użytkownika {user.Name} {user.Surname}");
            CSVManager.UpdateUsers(_userService.userList);
        }
        void UpdateUserPassword(User user)
        {
            _userService.UpdateUserPassword(user.Id, _cliHelper.GetSecureStringFromUser("Podaj nowe hasło: "));
            Console.WriteLine($"\nZmieniono hasło użytkownika {user.Name} {user.Surname}");
            CSVManager.UpdateUsers(_userService.userList);
        }
        void ShowUserProfile(User user)
        {
            Console.WriteLine($"Imię: {user.Name}");
            Console.WriteLine($"Nazwisko: {user.Surname}");
            Console.WriteLine($"Nazwa użytkownika: {user.DisplayName}");
            Console.WriteLine($"Email: {user.Email}");

            UpdateUserProfile(user);
            ChooseOperation(user);
        }
        void ChooseOperation(User user)
        {
            bool exit = false;
            do
            {
                Console.WriteLine($"Zalogowano jako: {user.Name} {user.Surname}\n");

                Console.WriteLine("1. Wyświetl profil użytkownika");
                Console.WriteLine("2. Pokaż zespoły");
                Console.WriteLine("3. Stwórz zespół");
                Console.WriteLine("4. Pokaż wydarzenia");
                Console.WriteLine("5. Stwórz wydarzenie");
                Console.WriteLine("6. Wyloguj się");

                int operation;
                operation = _cliHelper.GetIntFromUser("Podaj numer operacji");

                switch (operation)
                {
                    case 1:
                        ShowUserProfile(user);
                        break;
                    case 2:
                        Console.WriteLine("Zaimplementować!");
                        //ShowTeams(user);
                        break;
                    case 3:
                        AddNewTeam();
                        break;
                    case 4:
                        Console.WriteLine("Zaimplementować!");
                        //ShowEvents(user);
                        break;
                    case 5:
                        AddNewEvent();
                        break;
                    case 6:
                        exit = true;
                        WelcomeScreen();
                        break;
                    default:
                        Console.WriteLine($"Nie znaleziono opcji pod numerem {operation}");
                        break;
                }
            
            }while (!exit);
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
                        ChooseOperation(user);
                        break;

                    case 2:
                        UpdateUserDisplayName(user);
                        ShowUserProfile(user);
                        break;

                    case 3:
                        UpdateUserEmail(user);
                        ShowUserProfile(user);
                        break;

                    case 4:
                        UpdateUserPassword(user);
                        ShowUserProfile(user);
                        break;

                    default:
                        Console.WriteLine("Zły numer operacji! Wybierz poprawny numer operacji z zakresu 1-4");
                        break;
                }
            } while (!exit);
        }
        void ShowTeams()
        {
            //foreach (var item in collection)
            //{

            //}
        }

        void AddNewTeam()
        {
            var teamName = _cliHelper.GetStringFromUser("Podaj nazwę zespołu: ");
            var allUsers = CSVManager.GetUsers();
            string listOfUsersToDisplay = "";
            
            for (int i = 0; i < allUsers.Count; i++)
            {
                listOfUsersToDisplay += $"{i + 1} - {allUsers[i].Name} {allUsers[i].Surname}, {allUsers[i].DisplayName}, {allUsers[i].Email}\n";
            }
            

            var teamQuantity = _cliHelper.GetIntFromUser("Podaj liczbę członków zespołu: ");

            bool correctTeamQuantity = true;
            do
            {
                if (teamQuantity > 0 && teamQuantity <= allUsers.Count)
                {
                    correctTeamQuantity = true;
                }
                else
                {
                    correctTeamQuantity = false;
                    Console.WriteLine($"Wybrana zła liczba porządkowa. Proszę wybrać poprawną wartość większą od 0 i mniejszą niż {allUsers.Count+1}.");
                    teamQuantity = _cliHelper.GetIntFromUser($"\nPodaj liczbę członków zespołu: ");
                }
            } while (!correctTeamQuantity);

            List<Guid> teamMemberIds = new List<Guid>();
            for (int i = 1; i <= teamQuantity; i++)
            {

                var userId = _cliHelper.GetIntFromUser($"\n{listOfUsersToDisplay}\nPodaj liczbę porządkową użytkownika {i}, którego chcesz dodać do zespołu: ");

                bool correctIdQuantity = true;
                do
                {
                    if (userId <= 0 && userId > allUsers.Count)
                    {
                        correctIdQuantity = false;
                        Console.WriteLine($"Wybrana zła liczba porządkowa. Proszę wybrać poprawną wartość większą od 0 i mniejszą niż {allUsers.Count + 1}.");
                        userId = _cliHelper.GetIntFromUser($"\n{listOfUsersToDisplay}\nPodaj liczbę porządkową użytkownika {i}, którego chcesz dodać do zespołu: ");
                    }
                    else if (teamMemberIds.Contains(allUsers[userId-1].Id))
                    {
                        correctIdQuantity = false;
                        Console.WriteLine("Użytkownik z podaną liczbą porządkową już istnieje. Podaj inną wartość.");
                        userId = _cliHelper.GetIntFromUser($"\n{listOfUsersToDisplay}\nPodaj liczbę porządkową użytkownika {i}, którego chcesz dodać do zespołu: ");
                    }
                    else
                    {
                        correctIdQuantity = true;
                    }
                } while (!correctIdQuantity);

                teamMemberIds.Add(allUsers[userId-1].Id);
            }

            var newTeam = new Team(teamName,teamMemberIds);
            
            CSVManager.AddNewTeam(newTeam);

            Console.WriteLine($"\nDodano nowy zespół o nazwie {teamName}.");
        }

        void UpdateTeam()
        {

        }

        void AddNewEvent()
        {
            
        }
        void ShowEvents()
        {
            //foreach (var item in collection)
            //{

            //}

        }
    }
}        
        
        

        


        
        



       


