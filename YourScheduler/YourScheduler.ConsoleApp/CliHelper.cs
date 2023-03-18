namespace YourScheduler.ConsoleApp
{
    internal class CliHelper
    {
        internal string GetStringFromUser(string message)
        {
            Console.WriteLine($"{message}");
            return Console.ReadLine();
           
        }

        internal string GetSecureStringFromUser(string message)
        {
            Console.WriteLine($"{message}");
            var password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return password;
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

