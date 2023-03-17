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
            List<User> users = new List<User>();
            string[] linesFromCSV = System.IO.File.ReadAllLines(GetUsersFilePath());
            foreach (var line in linesFromCSV)
            {
                string[] splittedData = line.Split(',');
                User newUser = new User(name: splittedData[3], surname: splittedData[4], email: splittedData[1], displayName: splittedData[5], password: splittedData[2]);
                newUser.Id = Guid.Parse(splittedData[0]);
                users.Add(newUser);
            }
            return users;
        }
        public static void UpdateUsers(List <User> users)
        {
            string[] linesToCSV = new string[users.Count];
            for (int i = 0; i < users.Count; i++)
            {
                linesToCSV[i] = users[i].Id.ToString() + ",";
                linesToCSV[i] += users[i].Email + ",";
                linesToCSV[i] += users[i].Password + ",";
                linesToCSV[i] += users[i].Name + ",";
                linesToCSV[i] += users[i].Surname + ",";
                linesToCSV[i] += users[i].DisplayName;
            }
            File.WriteAllLines(GetUsersFilePath(), linesToCSV);
        }
        public static List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();
            string[] linesFromCSV = System.IO.File.ReadAllLines(GetEventsFilePath());
            foreach (var line in linesFromCSV)
            {
                string[] splittedData = line.Split(',');
                Guid newEventID = Guid.Parse(splittedData[0]);
                DateTime newEventDate = DateTime.Parse(splittedData[3]);
                List <Guid> newEventParticipants = new List<Guid>();

                if(splittedData[4] != "")
                {
                    string[] splittedEventParticipants = splittedData[4].Split('|');
                    foreach (var participantId in splittedEventParticipants)
                    {
                        newEventParticipants.Add(Guid.Parse(participantId));
                    }
                }
                bool newEventIsOpen = Convert.ToBoolean(splittedData[5]);
                Event newEvent = new Event(name: splittedData[1], description: splittedData[2], date: newEventDate, participants: newEventParticipants, isopen: newEventIsOpen);
                newEvent.Id = newEventID;
                events.Add(newEvent);
            }
            return events;
        }
        public static void UpdateEvents(List<Event> events)
        {
            string[] linesToCSV = new string[events.Count];
            for (int i = 0; i < events.Count; i++)
            {
                linesToCSV[i] = events[i].Id.ToString() + ",";
                linesToCSV[i] += events[i].Name + ",";
                linesToCSV[i] += events[i].Description + ",";
                linesToCSV[i] += events[i].Date.ToString() + ",";
                for (int j = 0; j < events[i].Participants.Count; j++)
                {
                    if (j == events[i].Participants.Count-1)
                    {
                        linesToCSV[i] += events[i].Participants[j].ToString() + ",";

                    }
                    else
                    {
                        linesToCSV[i] += events[i].Participants[j].ToString() + "|";
                    }
                }
                linesToCSV[i] += events[i].IsOpen.ToString();
            }
            File.WriteAllLines(GetEventsFilePath(), linesToCSV);
        }
    }
}
