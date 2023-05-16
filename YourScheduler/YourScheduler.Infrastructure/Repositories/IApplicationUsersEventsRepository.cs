using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories
{
    public interface IApplicationUsersEventsRepository
    {
        void AddEventForUser(int applicationUserId, int eventId);
        public void SaveData();

        public List<Event> GetEventsForUser(int applicationUserId);

    }
}