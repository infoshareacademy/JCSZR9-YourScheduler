using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories
{
    public interface IEventsRepository
    {
        public void AddEvent(Event eventTobase);

        public void SaveData();

        public List<Event> GetAvailableEvents();

        public Event GetEventById(int id);
    }
}
