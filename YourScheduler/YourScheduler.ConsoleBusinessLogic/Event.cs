using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.ConsoleBusinessLogic
{
    public class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<Guid> Participants { get; set; }
        public bool IsOpen { get; set; }

        public Event(string name, string description, DateTime date, List<Guid> participants, bool isopen)
        {
            Name = name;
            Description = description;
            Date = date;
            Participants = participants;
            IsOpen = isopen;
        }

        public void AddUser(Guid userID)
        {
            Participants.Add(userID);
        }
    }
}
