using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mapppers.Interfaces;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Services
{

    internal class ApplicationUserEventService : IApplicationUserEventService
    {
        private readonly IApplicationUsersEventsRepository _applicationUsersEventsRepository;

        private readonly IEventMapper _eventMapper;

        private readonly IUserMapper _userMapper;

        private readonly IEventService _eventService;

        public ApplicationUserEventService(IApplicationUsersEventsRepository applicationUsersEventsRepository,IEventMapper eventMapper, IUserMapper userMapper, IEventService eventService)
        {
            _applicationUsersEventsRepository = applicationUsersEventsRepository;
            _eventMapper = eventMapper;
            _userMapper = userMapper;
            _eventService = eventService;
        }

        public void AddEventForUser(int applicationUserId, int eventId)
        {
            _applicationUsersEventsRepository.AddEventForUser(applicationUserId, eventId);
            _applicationUsersEventsRepository.SaveData();
        }

        public List<EventDto> GetMyEvents(int applicationUserId, string searchString)
        {
            List<EventDto> myEvents = new List<EventDto>();
            var eventsForUser = _applicationUsersEventsRepository.GetEventsForUser(applicationUserId);
            foreach (var eventEntity in eventsForUser)
            {
                EventDto eventDto = new EventDto();
                eventDto = _eventMapper.EventToEventDtoMapp(eventEntity);
                myEvents.Add(eventDto);
            }
            if (String.IsNullOrEmpty(searchString))
            {
                return myEvents;
            }
            else
            {
                return myEvents.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public List<UserDto> GetUsersForEvent(int eventId)
        {
            List<UserDto> usersDtos = new List<UserDto>();
            var usersForEvents=_applicationUsersEventsRepository.GetApplicationUsersForEvent(eventId);

            foreach (var user in usersForEvents)
            {
                var userDto=_userMapper.UserToUserDtoMapp(user);
                usersDtos.Add(userDto);
            }
            return usersDtos;
        }

        public EventMembersDto GetEventMembersDto(int eventId)
        {
            var modelEvent = _eventService.GetEventById(eventId);
            EventMembersDto eventMembersDto = new EventMembersDto();
            eventMembersDto.Name = modelEvent.Name;
            eventMembersDto.Description = modelEvent.Description;
            eventMembersDto.Date = modelEvent.Date;
            eventMembersDto.Isopen = modelEvent.Isopen;
            eventMembersDto.EventUsers = GetUsersForEvent(eventId);
            return eventMembersDto;
        }

    }
}
