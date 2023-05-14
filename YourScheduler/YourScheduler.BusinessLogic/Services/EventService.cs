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
           var eventToBase= _mapper.EventDtoToEventMap(eventDto);   
            _eventsRepository.AddEvent(eventToBase);
            _eventsRepository.SaveData();
        }
    }
    
}
