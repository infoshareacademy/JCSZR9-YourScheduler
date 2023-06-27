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
            List<int> ids = new List<int>();
            List<Event> events = new List<Event>();

            events = _dbContext.ApplicationUsersEvents.Where(x => x.ApplicationUserId == applicationUserId).Select(x => x.Event).ToList();


            return events;
        }

        public List<ApplicationUser> GetApplicationUsersForEvent(int eventId)
        {
            List<ApplicationUser> applicationUsers = new List<ApplicationUser>();
            applicationUsers = _dbContext.ApplicationUsersEvents.Where(x => x.EventId == eventId).Select(x => x.ApplicationUser).ToList();
            return applicationUsers;
        }

        public bool CheckIfLoggedUserIsParticipant(int loggedUserId, int eventId)
        {
            var isLoggedUserParticipant = _dbContext.ApplicationUsersEvents.Any(e => e.ApplicationUserId == loggedUserId && e.EventId == eventId);
            return isLoggedUserParticipant;
        }
    }
}
