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
            User Kamil = new User("Kamil", "Majewski", "SomeMail@Mail.com", "Milva", "HiddenPW213");
            Kamil.ChangeEmail("   nnnn ");
            Console.WriteLine(Kamil.Email);
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
