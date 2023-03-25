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

            Program program = new Program();
            program.run();

        }

        public void run()
        {
            Menu menu = new Menu();
            menu.RunMenu();
        }

    }
}
