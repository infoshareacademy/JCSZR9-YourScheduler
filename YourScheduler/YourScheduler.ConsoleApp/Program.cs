using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic;
using YourScheduler.ConsoleApp;

namespace YourScheduler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj! Aplikacja YourScheduler \n");

            //Test do sprawdzenia czy działa ładowanie pliku
 
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
            Console.ReadLine();

            //Ten sam test dla eventów, tworzymy listę eventów i ładujemy do niej dane z pliku:

            List <Event> events = new List <Event> ();
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
            Console.ReadLine();
            


            /*
            //User Kamil = new User(0, "Kamil", "Majewski", "SomeMail@Mail.com", "Milva", "HiddenPW213");
            //Kamil.ChangeEmail("   nnnn ");
            //Console.WriteLine(Kamil.Email);
            //Program program = new Program();
            //program.run();
            */
        }
        /*
        private void run()
        {
            Menu menu = new Menu();
            menu.RunMenu();
        }
        */
    }
}
