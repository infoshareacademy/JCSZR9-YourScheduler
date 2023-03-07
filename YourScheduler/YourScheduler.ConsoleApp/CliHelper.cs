using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.ConsoleApp
{
    internal class CliHelper
    {
        private string GetInfoFromUser()
        {
            string infoFromKeyboard = "";
            infoFromKeyboard = Console.ReadLine();
            return infoFromKeyboard;
        }

        internal string GetStringFromUser(string message)
        {
            string infoFromUser = "";
            Console.WriteLine($"{message}");
            bool correctValue = false;
            do
            {
                infoFromUser = GetInfoFromUser();
                if (infoFromUser.Length == 0)
                {
                    correctValue = false;
                    Console.WriteLine("You have to get not empty string");
                }
                else
                {
                    correctValue = true;
                }
            } while (correctValue != true);
            return infoFromUser;
        }

        internal int GetIntFromUser(string message)
        {
            bool intCorrectValue = false;
            int result = 0;
            do
            {
                Console.WriteLine($"{message}");
                intCorrectValue = int.TryParse(GetInfoFromUser(), out result);
            } while (intCorrectValue != true || result == 0);

            return result;
        }

    }
}

