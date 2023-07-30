using Microsoft.AspNetCore.Http;
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
    public class EventsRepository : IEventsRepository
    {
        private readonly YourSchedulerDbContext _dbContext;
        private readonly ILogger _logger;

        public EventsRepository(YourSchedulerDbContext dbContext, ILogger<EventsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task AddEventAsync(Event eventTobase)
        {
            _logger.LogInformation("User attempt to add new event at {DT}", DateTime.Now.ToLongTimeString());
            await _dbContext.Events.AddAsync(eventTobase);
        }
        public async Task SaveDataAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Event>> GetAvailableEventsAsync(int loggedUserId)
        {
            _logger.LogInformation("User attempt to get available events at {DT}", DateTime.Now.ToLongTimeString());
            List<Event> events = new List<Event>();
            events = await _dbContext.Events.Where(i => i.IsOpen == true || i.administratorId == loggedUserId).ToListAsync();
            return events;
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            _logger.LogInformation("User attempt to get event by ID at {DT}", DateTime.Now.ToLongTimeString());
            return await _dbContext.Events.SingleOrDefaultAsync(x => x.EventId == id);
        }

        public async Task DeleteEventByIdAsync(int id)
        {
            _logger.LogInformation("User attempt to delete event by ID at {DT}", DateTime.Now.ToLongTimeString());
            var eventToDelete = await GetEventByIdAsync(id);
            if (eventToDelete != null)
            {
                _dbContext.Events.Remove(eventToDelete);
                var applicationUserEventsToDelete = _dbContext.ApplicationUsersEvents.Where(x => x.EventId == eventToDelete.EventId);
                _dbContext.ApplicationUsersEvents.RemoveRange(applicationUserEventsToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteEventFromCalendarByIdAsync(int id, int userId)
        {
            _logger.LogInformation("User attempt to delete event from calendar by ID at {DT}", DateTime.Now.ToLongTimeString());
            var eventToDelete = await GetEventByIdAsync(id);
            if (eventToDelete != null)
            {
                var applicationUsersEventToDelete = await _dbContext.ApplicationUsersEvents.SingleOrDefaultAsync(x=>x.EventId == eventToDelete.EventId && x.ApplicationUserId == userId);
                _dbContext.ApplicationUsersEvents.Remove(applicationUsersEventToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateEventAsync(Event eventToBase)
        {
            _logger.LogInformation("User attempt to update event at {DT}", DateTime.Now.ToLongTimeString());
            var eventToUpdate = await _dbContext.Events.SingleOrDefaultAsync(e => e.EventId == eventToBase.EventId);
            if (eventToUpdate != null)
            {
                eventToUpdate.Name = eventToBase.Name;
                eventToUpdate.Description = eventToBase.Description;
                eventToUpdate.Date = eventToBase.Date;
                eventToUpdate.IsOpen = eventToBase.IsOpen;
                eventToUpdate.administratorId = eventToBase.administratorId;
                if(eventToBase.PicturePath is null)
                {
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    eventToUpdate.PicturePath = eventToBase.PicturePath;
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> CheckIfLoggedUserIsParticipantAsync(int loggedUserId, int eventId)
        {
            var isLoggedUserParticipant = await _dbContext.ApplicationUsersEvents.AnyAsync(e => e.ApplicationUserId == loggedUserId && e.EventId == eventId);
            return isLoggedUserParticipant;
        }

        public async Task AddEventForUserAsync(int applicationUserId, int eventId)
        {
            _logger.LogInformation("User attempt to add event to own calendar at {DT}", DateTime.Now.ToLongTimeString());
            await _dbContext.ApplicationUsersEvents.AddAsync(new ApplicationUserEvent { ApplicationUserId = applicationUserId, EventId = eventId });
        }

        public async Task<List<Event>> GetEventsForUserAsync(int applicationUserId)
        {
            List<int> ids = new List<int>();
            List<Event> events = new List<Event>();
            events = await _dbContext.ApplicationUsersEvents.Where(x => x.ApplicationUserId == applicationUserId).Select(x => x.Event).ToListAsync();
            return events;
        }

        public async Task<List<ApplicationUser>> GetApplicationUsersForEventAsync(int eventId)
        {
            _logger.LogInformation("User attempt to get list of users for event {DT}", DateTime.Now.ToLongTimeString());
            List<ApplicationUser> applicationUsers = new List<ApplicationUser>();
            applicationUsers = await _dbContext.ApplicationUsersEvents.Where(x => x.EventId == eventId).Select(x => x.ApplicationUser).ToListAsync();
            return applicationUsers;
        }
    }
}
