using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler
{
    public class Teams
    {
        public void TeamsMethod()
        {

            while (true)
            {
                Console.WriteLine("1. Dodaj grupę");
                Console.WriteLine("2. Wyświetl listę grup");
                Console.WriteLine("3. Wyjdź");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Podaj nazwę grupy:");
                        string groupName = Console.ReadLine();
                        Console.WriteLine($"Dodano grupę {groupName}.");
                        break;
                    case 2:

                        break;
                    case 3:
                        Console.WriteLine("Do widzenia!");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Wybierz ponownie.");
                        break;
                }
            }
        }
    }


}
