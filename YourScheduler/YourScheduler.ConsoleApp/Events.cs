using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.ConsoleApp
{
    public class Event
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public void EditTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void EditDate(DateTime newDate)
        {
            Date = newDate;
        }

        public void EditLocation(string newLocation)
        {
            Location = newLocation;
        }

        public void EditDescription(string newDescription)
        {
            Description = newDescription;
        }
    }

    class EventsMethod
    {
        static List<Event> events = new List<Event>();

        public void MakeEvent()
        {
            while (true)
            {
                Console.WriteLine("Wybierz jedną z opcji: ");
                Console.WriteLine("1. Wyświetl wydarzenia");
                Console.WriteLine("2. Dodaj nowe wydarzenie");
                Console.WriteLine("3. Modyfikuj istniejące wydarzenie");
                Console.WriteLine("4. Usuń wydarzenie");
                Console.WriteLine("5. Wyjdź");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayEvents();
                        break;
                    case 2:
                        AddEvent();
                        break;
                    case 3:
                        EditEvent();
                        break;
                    case 4:
                        //DeleteEvent(); //DOROBIĆ!!!
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór, spróbuj ponownie.");
                        break;
                }
            }
        }

        static void DisplayEvents()
        {
            if (events.Count == 0)
            {
                Console.WriteLine("Brak wydarzeń.");
            }
            else
            {
                foreach (Event dupa in events)
                {
                    Console.WriteLine("{0} - {1} ({2}) - {3}", dupa.Title, dupa.Date.ToString("dd/MM/yyyy"), dupa.Location, dupa.Description);
                }
            }
        }

        static void AddEvent()
        {
            
        }

        static void EditEvent()
        {
            Console.Write("Podaj tytuł wydarzenia do edycji: ");
            string title = Console.ReadLine();

            Event dupa = events.Find(kibel => kibel.Title == title);

            if (dupa == null)
            {
                Console.WriteLine("Nie znaleziono wydarzenia o podanym tytule.");
            }
            else
            {
                Console.WriteLine("Wybierz, co chcesz edytować: ");
                Console.WriteLine("1. Tytuł");
                Console.WriteLine("2. Datę");
                Console.WriteLine("3. Miejsce");
                Console.WriteLine("4. Opis");

                int choice = int.Parse(Console.ReadLine());
            }
        }
    }
}           

