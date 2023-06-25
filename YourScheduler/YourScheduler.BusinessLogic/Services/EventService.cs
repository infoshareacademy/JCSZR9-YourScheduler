using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mappers;
using YourScheduler.BusinessLogic.Mapppers.Interfaces;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Services
{
    public class EventService : IEventService
    {
        private readonly IEventsRepository _eventsRepository;

        private readonly IEventMapper _eventMapper;
        public EventService(IEventsRepository eventsRepository,IEventMapper eventMapper)
        {
            _eventMapper = eventMapper;
            _eventsRepository = eventsRepository;
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
                eventDto.LoggedUserId = loggedUserId;
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
            eventDto.LoggedUserId = loggedUserId;
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
    }

}
