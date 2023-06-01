using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly YourSchedulerDbContext _dbContext;

        public EventsRepository(YourSchedulerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddEvent(Event eventTobase)
        {
            _dbContext.Events.Add(eventTobase);

        }
        public void SaveData()
        {
            _dbContext.SaveChanges();
        }

        public List<Event> GetAvailableEvents()
        {
            List<Event> events = new List<Event>();

            return events = _dbContext.Events.ToList();
        }

        public Event GetEventById(int id)
        {
            return _dbContext.Events.SingleOrDefault(x => x.EventId == id);
        }

        public void DeleteEventById(int id)
        {
            var eventToDelete = GetEventById(id);
            if (eventToDelete != null)
            {
                _dbContext.Events.Remove(eventToDelete);
                var applicationUserEventsToDelete = _dbContext.ApplicationUsersEvents.Where(x => x.EventId == eventToDelete.EventId);
                _dbContext.ApplicationUsersEvents.RemoveRange(applicationUserEventsToDelete);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteEventFromCalendarById(int id, int userId)
        {
            var eventToDelete = GetEventById(id);
            if (eventToDelete != null)
            {
                var applicationUsersEventToDelete = _dbContext.ApplicationUsersEvents.SingleOrDefault(x=>x.EventId == eventToDelete.EventId && x.ApplicationUserId == userId);
                _dbContext.ApplicationUsersEvents.Remove(applicationUsersEventToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
