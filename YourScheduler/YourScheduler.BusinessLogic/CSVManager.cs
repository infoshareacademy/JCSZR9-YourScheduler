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
        static string projectDirectory = Directory.GetParent((Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString())).ToString();
        static string usersFileName = "users.csv";
        static string eventsFileName = "events.csv";
        public static string GetUsersFilePath()
        {
            string filePath = Path.Combine(projectDirectory, "YourScheduler.BusinessLogic", "Data", usersFileName);
            return filePath;
        }
        public static string GetEventsFilePath()
        {
            string filePath = Path.Combine(projectDirectory, "YourScheduler.BusinessLogic", "Data", eventsFileName);
            return filePath;
        }
        public static List<User> GetUsers()
        {
            List<User> users = new List<User> ();
            string[] linesFromCSV = System.IO.File.ReadAllLines(GetUsersFilePath());
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
        public static void UpdateUsers(List <User> users)
        {
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
            File.WriteAllLines(GetUsersFilePath(), linesToCSV);
        }
    }
}
