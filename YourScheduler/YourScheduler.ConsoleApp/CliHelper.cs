using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.ConsoleApp
{
    internal class CliHelper
    {
        internal string GetStringFromUser(string message)
        {
            Console.WriteLine($"{message}");
            return Console.ReadLine();
           
        }

      
        internal int GetIntFromUser(string message)
        {
            bool intCorrectValue = false;
            int result = 0;
            do
            {
                string text = GetStringFromUser(message);    
                intCorrectValue = int.TryParse(text, out result);
            } while (intCorrectValue != true || result == 0);

            return result;
        }

    }
}

