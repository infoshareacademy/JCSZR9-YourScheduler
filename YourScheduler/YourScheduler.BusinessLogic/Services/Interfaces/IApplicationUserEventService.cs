using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface IApplicationUserEventService
    {
        public void AddEventForUser(int applicationUserId, int eventId);

        public List<EventDto> GetMyEvents(int applicationUserId, string searchString);

        public List<UserDto> GetUsersForEvent(int eventId);

        public EventMembersDto GetEventMembersDto(int eventId);

    }
}
