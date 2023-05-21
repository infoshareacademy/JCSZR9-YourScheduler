using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Mapppers
{
    public interface IEventMapper
    {
         EventDto EventToEventDtoMapp(Event eventToBase);
         Event EventDtoToEventMap(EventDto eventDto);
    }
}
