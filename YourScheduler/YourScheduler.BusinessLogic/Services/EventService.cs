using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mappers;
using YourScheduler.BusinessLogic.Mapppers;
using YourScheduler.BusinessLogic.Models;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.BusinessLogic.Services
{
    public class EventService : IEventService
    {
        private readonly IEventsRepository _eventsRepository;

        private readonly EventMapper _mapper;
        public EventService(IEventsRepository eventsRepository)
        {
            _mapper = new EventMapper();
            _eventsRepository = eventsRepository;
        }

        public void AddEvent(EventDto eventDto)
        {
            var eventToBase = _mapper.EventDtoToEventMap(eventDto);
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
                eventDto = _mapper.EventToEventDtoMapp(eventFromDatabase);
                eventsDto.Add(eventDto);
            }
            return eventsDto;
        }

        public EventDto GetEventById(int id)
        {
            var eventFromDataBase= _eventsRepository.GetEventById(id);
            return _mapper.EventToEventDtoMapp(eventFromDataBase);
        }
    }

}
