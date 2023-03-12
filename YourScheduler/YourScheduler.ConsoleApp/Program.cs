using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic;

namespace YourScheduler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CSVManager.GetUsersFilePath());
            Console.WriteLine(CSVManager.GetEventsFilePath());
            Console.WriteLine();

            Console.WriteLine("Witaj! Aplikacja YourScheduler");
            
            List <User> users = CSVManager.GetUsers();

            foreach (var user in users)
            {
                Console.WriteLine(user.Id);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Password);
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Surname);
                Console.WriteLine(user.DisplayName);
                Console.WriteLine();
            }

            Console.WriteLine("----------------------------");
            Console.ReadLine();

            users.Add(new User { Id = 3, Email = "dupaduap", Password = "ksjdnfkjshdf", Name = "aaabb", Surname = "plpko", DisplayName = "eirut" });
            users.Add(new User { Id = 89, Email = "a@b", Password = "hh", Name = "oo", Surname = "qq", DisplayName = "1233" });
            users.Add(new User { Id = 7, Email = "iuuio67", Password = "dsfgdfg", Name = "oo", Surname = "qq", DisplayName = "yjghjhg" });


            CSVManager.UpdateUsers(users);

            List<User> users2 = CSVManager.GetUsers();

            foreach (var user in users2)
            {
                Console.WriteLine(user.Id);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Password);
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Surname);
                Console.WriteLine(user.DisplayName);
                Console.WriteLine();
            }
        }
    }
}
