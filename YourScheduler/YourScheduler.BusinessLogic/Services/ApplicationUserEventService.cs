﻿using Microsoft.EntityFrameworkCore.Query.Internal;
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
        public ApplicationUserEventService(IApplicationUsersEventsRepository applicationUsersEventsRepository,IEventMapper eventMapper)
        {
            _applicationUsersEventsRepository = applicationUsersEventsRepository;
            _eventMapper = eventMapper; 
        }

        public void AddEventForUser(int applicationUserId, int eventId)
        {
            _applicationUsersEventsRepository.AddEventForUser(applicationUserId, eventId);
            _applicationUsersEventsRepository.SaveData();
        }

        public List<EventDto> GetMyEvents(int applicationUserId)
        {
            List<EventDto> myEvents = new List<EventDto>();

            var eventsForUser = _applicationUsersEventsRepository.GetEventsForUser(applicationUserId);
            foreach (var eventEntity in eventsForUser)
            {
                EventDto eventDto = new EventDto();
                eventDto=_eventMapper.EventToEventDtoMapp(eventEntity);
                myEvents.Add(eventDto);
            }       
          
            return myEvents;
        }
    }
}