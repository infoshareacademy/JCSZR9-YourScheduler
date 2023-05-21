using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;

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
    }
}
