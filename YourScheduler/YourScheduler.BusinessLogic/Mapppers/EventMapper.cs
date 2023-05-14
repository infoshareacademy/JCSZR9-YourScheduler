using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Mapppers
{
    public class EventMapper
    {
        public EventDto EventToEventDtoMapp(Event eventToBase)
        {
            EventDto eventDto = new EventDto()
            {
               Name=eventToBase.Name,
               Description=eventToBase.Description,
               Date=eventToBase.Date,
               Isopen=eventToBase.IsOpen,
            };
            return eventDto;
        }

        public Event EventDtoToEventMap(EventDto eventDto)
        {
            Event eventToBase = new Event
            {
               Name = eventDto.Name,
               Description=eventDto.Description,
               Date=eventDto.Date,
               IsOpen=eventDto.Isopen,
            };
            return eventToBase;
        }
    }
}
