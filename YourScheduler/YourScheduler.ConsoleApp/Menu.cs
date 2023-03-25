using System.ComponentModel;
using YourScheduler.BusinessLogic;

namespace YourScheduler.ConsoleApp
{
    public class Menu
    {
        static Menu() 
        {
            CSVManager.AddNewUser(_currentUser);
        }

        private readonly static User _currentUser = new User("Marcin", "Dylowicz", "mar@test.com", "marcin77", "password321");
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
                Console.WriteLine("8 - Dodaj zespół");
                Console.WriteLine("9 - Edytuj zespół");


                int operation;
                do
                {
                    operation = _cliHelper.GetIntFromUser("\nWybierz numer operacji: ");
                } while (operation < 0 || operation > 9);

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
                        AddNewEvent();
                        break;
                    case 6:
                        AddNewUser();
                        break;
                    case 7:
                        UpdateUserProfile();
                        break;
                    case 8:
                        AddNewTeam();
                        break;
                    case 9:
                        UpdateTeam();
                        break;

                    default:
                        Console.WriteLine("Zły numer operacji! Wybierz poprawny numer operacji z zakresu 1-9");
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

        void AddNewTeam()
        {
            var teamName = _cliHelper.GetStringFromUser("Podaj nazwę zespołu: ");
            var allUsers = CSVManager.GetUsers();
            
            for (int i = 0; i < allUsers.Count; i++)
            {
                Console.WriteLine($"{i+1} - {allUsers[i].Name} {allUsers[i].Surname}, {allUsers[i].DisplayName}, {allUsers[i].Email}");
            }

            var teamQuantity = _cliHelper.GetIntFromUser("\nPodaj liczbę członków zespołu: ");

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
                    teamQuantity = _cliHelper.GetIntFromUser("\nPodaj liczbę członków zespołu: ");
                }
            } while (!correctTeamQuantity);

            List<Guid> teamMemberIds = new List<Guid>();
            for (int i = 1; i <= teamQuantity; i++)
            {
                var userId = _cliHelper.GetIntFromUser($"\nPodaj liczbę porządkową użytkownika {i}, którego chcesz dodać do zespołu: ");

                bool correctIdQuantity = true;
                do
                {
                    if (userId <= 0 && userId > allUsers.Count)
                    {
                        correctIdQuantity = false;
                        Console.WriteLine($"Wybrana zła liczba porządkowa. Proszę wybrać poprawną wartość większą od 0 i mniejszą niż {allUsers.Count + 1}.");
                        userId = _cliHelper.GetIntFromUser($"\nPodaj liczbę porządkową użytkownika {i}, którego chcesz dodać do zespołu: ");
                    }
                    else if (teamMemberIds.Contains(allUsers[userId-1].Id))
                    {
                        correctIdQuantity = false;
                        Console.WriteLine("Użytkownik z podaną liczbą porządkową już istnieje. Podaj inną wartość.");
                        userId = _cliHelper.GetIntFromUser($"\nPodaj liczbę porządkową użytkownika {i}, którego chcesz dodać do zespołu: ");
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


