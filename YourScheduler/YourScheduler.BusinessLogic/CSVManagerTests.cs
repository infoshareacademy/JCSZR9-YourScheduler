using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.BusinessLogic
{
    public class CSVManagerTests
    {
        public static void Run()
        {
            //Test do sprawdzenia czy działa praca z plikami
            
            Console.WriteLine("Witaj! Testowanie obsługi plików \n");
            
            //Tworzymy swoją listę userów:
            List<User> users = new List<User>();

            //Ładujemy do listy dane z pliku:
            users = CSVManager.GetUsers();

            //Wyświetlamy aktualną listę userów:
            Console.WriteLine("Lista userów załadowana z pliku: \n");
            foreach (var user in users)
            {
                Console.WriteLine($"users ID: {user.Id}");
                Console.WriteLine($"users Email: {user.Email}");
                Console.WriteLine($"users Password: {user.Password}");
                Console.WriteLine($"users Name: {user.Name}");
                Console.WriteLine($"users Surname: {user.Surname}");
                Console.WriteLine($"users DisplayName: {user.DisplayName}");
                Console.WriteLine();
            }
            Console.WriteLine("Wciśnij enter aby przejść dalej");
            Console.ReadLine();

            //Teraz dodajemy swoich userów do listy:
            users.Add(new User("Janusz", "Kowalski", "abc@mail.com", "janusz69", "haslohaslo123"));
            users.Add(new User("Bogusław", "Łęcina", "def@mail.com", "fuszerka0", "pykpykpyk"));

            //Aktualizujemy plik z userami:
            CSVManager.UpdateUsers(users);

            //Możemy sprawdzić czy plik na dysku się zaktualizował lub ponownie go załadować i wyświetlić:
            users = CSVManager.GetUsers();
            Console.WriteLine("Lista userów załadowana z pliku po dodaniu nowych userów: \n");
            foreach (var user in users)
            {
                Console.WriteLine($"users ID: {user.Id}");
                Console.WriteLine($"users Email: {user.Email}");
                Console.WriteLine($"users Password: {user.Password}");
                Console.WriteLine($"users Name: {user.Name}");
                Console.WriteLine($"users Surname: {user.Surname}");
                Console.WriteLine($"users DisplayName: {user.DisplayName}");
                Console.WriteLine();
            }
            Console.WriteLine("Wciśnij enter aby przejść dalej");
            Console.ReadLine();

            //Ten sam test dla eventów

            //Tworzymy swoją listę eventów:

            List<Event> events = new List<Event>();

            //Ładujemy do listy dane z pliku:

            events = CSVManager.GetEvents();

            //Wyświetlamy aktualną listę eventów:
            Console.WriteLine("Lista eventów załadowana z pliku: \n");
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
            Console.WriteLine("Wciśnij enter aby przejść dalej");
            Console.ReadLine();

            //Teraz dodajemy swoje eventy do listy:
            //roboczo tworzę listę z Guidami fikcyjnych użytkowników będących zapisanych na wydarzenia:
            List<Guid> eventParticipantsList = new List<Guid>();
            eventParticipantsList.Add(Guid.NewGuid());
            eventParticipantsList.Add(Guid.NewGuid());

            events.Add(new Event(name: "impreza urodzinowa Mariusza", description: "impreza z okazji urodzin", isopen: false, date: DateTime.Now, participants: eventParticipantsList));
            events.Add(new Event(name: "wyjście do kina", description: "obejrzenie nowego filmu marvela w kinie w kinie helios", isopen: true, date: DateTime.Now.AddDays(2), participants: eventParticipantsList));

            //Aktualizujemy plik z eventami:
            CSVManager.UpdateEvents(events);

            //Możemy sprawdzić czy plik na dysku się zaktualizował lub ponownie go załadować i wyświetlić:
            events = CSVManager.GetEvents();
            Console.WriteLine("Lista eventów załadowana z pliku po dodaniu nowych eventów: \n");
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
            Console.WriteLine("Wciśnij enter aby przejść dalej");
            Console.ReadLine();
            
            //Ten sam test dla teamów

            //Tworzymy swoją listę teamów:
            List<Team> teams = new List<Team>();

            //Ładujemy do listy dane z pliku:
            teams = CSVManager.GetTeams();

            //Wyświetlamy aktualną listę teamów:
            Console.WriteLine("Lista teamów załadowana z pliku: \n");
            foreach (var team in teams)
            {
                Console.WriteLine($"team ID: {team.Id}");
                Console.WriteLine($"team Name: {team.Name}");
                foreach (var memberID in team.Members)
                {
                    Console.WriteLine($"member Id: {memberID}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Wciśnij enter aby przejść dalej");
            Console.ReadLine();

            //Teraz dodajemy swoje teamy do listy:
            Team team1 = new Team();
            team1.Name = "grupa uderzeniowa";
            team1.Members.Add(Guid.NewGuid());
            Team team2 = new Team();
            team2.Name = "Grupa nygusów";
            team2.Members.Add(Guid.NewGuid());
            team2.Members.Add(Guid.NewGuid());
            teams.Add(team1);
            teams.Add(team2);
            //teams.Add(new Team());
            //teams.Last().Name = "grupa uderzeniowa";
            //teams.Last().Members.Add(Guid.NewGuid());
            //teams.Last().Members.Add(Guid.NewGuid());
            //teams.Add(new Team());
            //teams.Last().Name = "szkoła taneczna";
            //teams.Last().Members.Add(Guid.NewGuid());
            //teams.Last().Members.Add(Guid.NewGuid());

            //Aktualizujemy plik z eventami:
            CSVManager.UpdateTeams(teams);

            //Możemy sprawdzić czy plik na dysku się zaktualizował lub ponownie go załadować i wyświetlić:
            Console.WriteLine("Lista teamów załadowana z pliku po dodaniu własnych teamów: \n");
            foreach (var team in teams)
            {
                Console.WriteLine($"team ID: {team.Id}");
                Console.WriteLine($"team Name: {team.Name}");
                foreach (var memberID in team.Members)
                {
                    Console.WriteLine($"member Id: {memberID}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Wciśnij enter aby przejść dalej");
            Console.ReadLine();
        }
    }
}
