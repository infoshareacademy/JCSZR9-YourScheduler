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

        //public List<EventDto> GetAvailableEvents()
        //{
        //   
        //}

        public List<EventDto> GetAvailableEvents()
        {
            List<EventDto> eventsDto = new List<EventDto>();

            foreach (var eventFromDatabase in _eventsRepository.GetAvailableEvents())
            {
                EventDto eventDto = new EventDto();
                eventDto = _eventMapper.EventToEventDtoMapp(eventFromDatabase);
                eventsDto.Add(eventDto);
            }
            return eventsDto;
        }

        public EventDto GetEventById(int id)
        {
            var eventFromDataBase= _eventsRepository.GetEventById(id);
            return _eventMapper.EventToEventDtoMapp(eventFromDataBase);
        }
    }

}
