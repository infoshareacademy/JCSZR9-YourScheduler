using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models;

namespace YourScheduler.BusinessLogic.Services
{
    public interface IApplicationUserEventService
    {
        public void AddEventForUser(int applicationUserId, int eventId);

        public List<EventDto> GetMyEvents(int applicationUserId);

    }
}
