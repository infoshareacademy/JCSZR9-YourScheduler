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
    }
}
