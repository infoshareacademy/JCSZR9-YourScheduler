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

            CSVManagerTests.Run();

            //Menu.RunMenu();

            /*
            //User Kamil = new User(0, "Kamil", "Majewski", "SomeMail@Mail.com", "Milva", "HiddenPW213");
            //Kamil.ChangeEmail("   nnnn ");
            //Console.WriteLine(Kamil.Email);
            */
            //Program program = new Program();
            //program.run();
            
        }

        //public void run()
        //{
        //    Menu menu = new Menu();
        //    menu.RunMenu();
        //}

    }
}
