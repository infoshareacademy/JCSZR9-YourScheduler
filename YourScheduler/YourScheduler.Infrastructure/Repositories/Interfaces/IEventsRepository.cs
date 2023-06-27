using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories.Interfaces
{
    public interface IEventsRepository
    {
        public void AddEvent(Event eventTobase);

        public void SaveData();

        public List<Event> GetAvailableEvents(int loggedUserId);

        public Event GetEventById(int id);
        public void DeleteEventById(int id);
        public void DeleteEventFromCalendarById(int id, int userId);
        public void UpdateEvent(Event eventToBase);
        public bool CheckIfLoggedUserIsParticipant(int loggedUserId, int eventId);
    }
}
