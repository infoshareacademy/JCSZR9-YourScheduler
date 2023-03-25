namespace YourScheduler.ConsoleApp
{
    internal class CliHelper
    {
        internal string GetStringFromUser(string message)
        {
            var text = string.Empty;
            bool textCorrectValue = true;

            do
            {
                Console.WriteLine($"{message}");
                text = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(text))
                {
                    textCorrectValue = false;
                    Console.WriteLine("Nieprawidłowa wartość. Wartość nie może być pusta.");
                }
                else
                {
                    textCorrectValue = true;
                }

            } while(!textCorrectValue);
            Console.Clear();
            return text;
        } 

        internal string GetSecureStringFromUser(string message)
        {
            var password = string.Empty;
            bool passwordCorrectValue = true;

            do
            {
                Console.WriteLine($"{message}");
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

                if (password.Length >= 8 && password.Length <= 24 && !string.IsNullOrWhiteSpace(password))
                {
                    passwordCorrectValue = true;
                }
                else
                {
                    passwordCorrectValue = false;
                    Console.WriteLine("\nNieprawidłowa wartość. Hasło powinno zawierać od 8 do 24 znaków.");
                }
            } while (!passwordCorrectValue);
            
            return password;
        }


        internal string GetEmailFromUser(string message)
        {
            bool emailCorrectValue = true;
            var email = string.Empty;

            do
            {
                email = GetStringFromUser(message);

                if (!email.Contains('@') || email.Length < 3)
                {
                    emailCorrectValue = false;
                    Console.WriteLine("Niepoprawny email. Powinien składać się co najmniej z 3 znaków gdzie co najmniej jeden z nich to @.");
                }
                else
                {
                    emailCorrectValue = true;
                }

            } while (!emailCorrectValue);

            return email;
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

        internal DateTime GetDateFromUser(string message)
        {
            bool dateTimeCorrectValue = false;
            DateTime result;
            do
            {
                string date = GetStringFromUser(message);
                dateTimeCorrectValue = DateTime.TryParse(date, out result);
            } while (dateTimeCorrectValue != true);

            return result;
        }

    }
}

