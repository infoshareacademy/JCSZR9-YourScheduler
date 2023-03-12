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
       // User someuser = new User();
        static void Main(string[] args)
        {         
            Program program = new Program();
            program.run();
        }

        private void run()
        {
            Menu menu = new Menu();
            menu.RunMenu();
        }
    }

}
