using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mapppers.Interfaces;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Mapppers
{
    public class EventMapper:IEventMapper
    {
        public EventDto EventToEventDtoMapp(Event eventToBase)
        {
            EventDto eventDto = new EventDto()
            {
               Id = eventToBase.EventId,
               Name = eventToBase.Name,
               Description = eventToBase.Description,
               Date = eventToBase.Date,
               Isopen = eventToBase.IsOpen,
               administratorId = eventToBase.administratorId
            };
            return eventDto;
        }

        public Event EventDtoToEventMap(EventDto eventDto)
        {
            Event eventToBase = new Event
            {
               Name = eventDto.Name,
               Description = eventDto.Description,
               Date = eventDto.Date,
               IsOpen = eventDto.Isopen,
               administratorId= eventDto.administratorId
            };
            return eventToBase;
        }

        public Event EventDtoWithIdToEventMap(EventDto eventDto)
        {
            Event eventToBase = new Event
            {
                EventId = eventDto.Id,
                Name = eventDto.Name,
                Description = eventDto.Description,
                Date = eventDto.Date,
                IsOpen = eventDto.Isopen,
                administratorId = eventDto.administratorId
            };
            return eventToBase;
        }
    }
}
