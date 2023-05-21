using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Repositories
{
    public class ApplicationUsersEventsRepository : IApplicationUsersEventsRepository
    {
        private readonly YourSchedulerDbContext _dbContext;

        public ApplicationUsersEventsRepository(YourSchedulerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddEventForUser(int applicationUserId, int eventId)
        {
            _dbContext.ApplicationUsersEvents.Add(new ApplicationUserEvent { ApplicationUserId = applicationUserId, EventId = eventId });
        }

        public void SaveData()
        {
            _dbContext.SaveChanges();
        }

        public List<Event> GetEventsForUser(int applicationUserId)
        {
            List<int> ids=new List<int>();
            List<Event> events = new List<Event>();

             ids = _dbContext.ApplicationUsersEvents.Where(x=>x.ApplicationUserId==applicationUserId).Select(x=>x.EventId).ToList();

            //foreach (var item in _dbContext.ApplicationUsersEvents)
            //{
            //    if (item.ApplicationUserId == applicationUserId)
            //    {
            //        ids.Add(item.EventId);
            //    }

            //}

            // events=_dbContext.Events.Where(x=>x.EventId==x.EventId).ToList();

            foreach (var eventId in ids)
            {
                var eventFromDatabase = _dbContext.Events.FirstOrDefault(e => e.EventId == eventId);
                events.Add(eventFromDatabase);
            }


            return events;        
        }
    }
}
