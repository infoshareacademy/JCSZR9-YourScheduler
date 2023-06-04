using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Repositories
{
    public class AllEventsRepository : IEventsRepository
    {
        private readonly YourSchedulerDbContext _dbContext;

        public AllEventsRepository(YourSchedulerDbContext dbContext)
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
            //List<Event> events = new List<Event>();

            return _dbContext.Events.ToList();
        }

        public Event GetEventById(int id)
        {
            return _dbContext.Events.SingleOrDefault(x => x.EventId == id);
        }
    }
}
