using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            Menu program = new Menu();
            program.RunMenu();
        }
    }
}
