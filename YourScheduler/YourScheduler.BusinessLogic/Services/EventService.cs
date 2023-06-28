using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mappers;
using YourScheduler.BusinessLogic.Mapppers.Interfaces;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Services
{
    public class EventService : IEventService
    {
        private readonly IEventsRepository _eventsRepository;

        private readonly IEventMapper _eventMapper;

        private readonly IUserMapper _userMapper;

        public EventService(IEventsRepository eventsRepository,IEventMapper eventMapper, IUserMapper userMapper)
        {
            _eventMapper = eventMapper;
            _eventsRepository = eventsRepository;
            _userMapper = userMapper;
        }

        public void AddEvent(EventDto eventDto)
        {
            var eventToBase = _eventMapper.EventDtoToEventMap(eventDto);
            _eventsRepository.AddEvent(eventToBase);
            _eventsRepository.SaveData();
        }

        public List<EventDto> GetAvailableEvents(int loggedUserId, string searchString)
        {
            List<EventDto> eventsDto = new List<EventDto>();
            foreach (var eventFromDatabase in _eventsRepository.GetAvailableEvents(loggedUserId))
            {
                EventDto eventDto = new EventDto();
                eventDto = _eventMapper.EventToEventDtoMapp(eventFromDatabase);
                if (loggedUserId == eventDto.AdministratorId)
                {
                    eventDto.CanLoggedUserDelete = true;
                    eventDto.CanLoggedUserEdit = true;
                }
                eventDto.IsLoggedUserParticipant = _eventsRepository.CheckIfLoggedUserIsParticipant(loggedUserId, eventDto.Id);
                eventsDto.Add(eventDto);
            }
            if (String.IsNullOrEmpty(searchString))
            {
                return eventsDto;
            }
            else
            {
                return eventsDto.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public EventDto GetEventById(int id, int loggedUserId)
        {
            var eventFromDataBase= _eventsRepository.GetEventById(id);
            var eventDto = _eventMapper.EventToEventDtoMapp(eventFromDataBase);
            if (loggedUserId == eventDto.AdministratorId)
            {
                eventDto.CanLoggedUserDelete = true;
                eventDto.CanLoggedUserEdit = true;
            }
            eventDto.IsLoggedUserParticipant = _eventsRepository.CheckIfLoggedUserIsParticipant(loggedUserId, eventDto.Id);
            return eventDto;
        }

        public void DeleteEvent(int id)
        {
            _eventsRepository.DeleteEventById(id);
        }

        public void DeleteEventFromCalendar(int id, int userId)
        {
            _eventsRepository.DeleteEventFromCalendarById(id, userId);
        }

        public void UpdateEvent(EventDto eventDto)
        {
            var eventToBase = _eventMapper.EventDtoWithIdToEventMap(eventDto);
            _eventsRepository.UpdateEvent(eventToBase);
        }

        public void AddEventForUser(int applicationUserId, int eventId)
        {
            _eventsRepository.AddEventForUser(applicationUserId, eventId);
            _eventsRepository.SaveData();
        }

        public List<EventDto> GetMyEvents(int applicationUserId, string searchString)
        {
            List<EventDto> myEvents = new List<EventDto>();
            var eventsForUser = _eventsRepository.GetEventsForUser(applicationUserId);
            foreach (var eventEntity in eventsForUser)
            {
                EventDto eventDto = new EventDto();
                eventDto = _eventMapper.EventToEventDtoMapp(eventEntity);
                if (applicationUserId == eventEntity.administratorId)
                {
                    eventDto.CanLoggedUserDelete = true;
                    eventDto.CanLoggedUserEdit = true;
                }
                eventDto.IsLoggedUserParticipant = _eventsRepository.CheckIfLoggedUserIsParticipant(applicationUserId, eventDto.Id);
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
            var usersForEvents = _eventsRepository.GetApplicationUsersForEvent(eventId);

            foreach (var user in usersForEvents)
            {
                var userDto = _userMapper.UserToUserDtoMapp(user);
                usersDtos.Add(userDto);
            }
            return usersDtos;
        }

        public EventMembersDto GetEventMembersDto(int eventId, int loggedUserId)
        {
            var modelEvent = GetEventById(eventId, loggedUserId);
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
