﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface IEventService
    {
        public void AddEvent(EventDto eventDto);

        public List<EventDto> GetAvailableEvents(int loggedUserId, string searchString);

        public EventDto GetEventById(int id, int loggedUserId);

        public void DeleteEvent(int id);

        public void DeleteEventFromCalendar(int id, int userId);

        public void UpdateEvent(EventDto model);
    }
}
