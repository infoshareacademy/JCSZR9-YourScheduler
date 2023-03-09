using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.BusinessLogic
{
    public class CSVManager
    {
        public static List<User> GetUsers(string fileName)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "Data", fileName);
 
            List<User> users = new List<User> ();
            string[] linesFromCSV = System.IO.File.ReadAllLines(filePath);
            foreach (var line in linesFromCSV)
            {
                User newUser = new User();
                string[] splittedData = line.Split(',');
                newUser.Id = Convert.ToInt32(splittedData[0]);
                newUser.Email = splittedData[1];
                newUser.Password = splittedData[2];
                newUser.Name = splittedData[3];
                newUser.Surname = splittedData[4];
                newUser.DisplayName = splittedData[5];
                users.Add(newUser);
            }
            return users;
        }
        public static void UpdateUsers(List <User> users, string fileName)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "Data", fileName);
            string[] linesToCSV = new string[users.Count];
            for (int i = 0; i < users.Count; i++)
            {
                linesToCSV[i] = Convert.ToString(users[i].Id) + ",";
                linesToCSV[i] += users[i].Email + ",";
                linesToCSV[i] += users[i].Password + ",";
                linesToCSV[i] += users[i].Name + ",";
                linesToCSV[i] += users[i].Surname + ",";
                linesToCSV[i] += users[i].DisplayName;
            }
            File.WriteAllLines(filePath, linesToCSV);
        }
    }
}
