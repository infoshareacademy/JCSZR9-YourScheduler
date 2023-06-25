using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.WebApplication.Controllers
{
    public class ApplicationUserEventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IApplicationUserEventService _applicationUserEventService;

        public ApplicationUserEventController(IEventService eventService, IApplicationUserEventService applicationUserEventService)
        {
            _eventService = eventService;
            _applicationUserEventService = applicationUserEventService;
        }

        // GET: ApplicationUserEventController/Delete/5
        [Route("addthisevent/{id:int}")]
        public ActionResult AddThisEvent(int eventId)
        {

            var model = _eventService.GetEventById(eventId);
            return View(model);
        }

        // POST: ApplicationUserEventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("addthisevent/{id:int}")]
        public ActionResult AddThisEvent(EventDto model)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var eventToAddId = model.Id;
                _applicationUserEventService.AddEventForUser(loggedUserId, eventToAddId);
                return RedirectToAction("Index", "Event");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Event");
            }
        }

        public ActionResult MyEvents(string searchString)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = _applicationUserEventService.GetMyEvents(loggedUserId);
            if (String.IsNullOrEmpty(searchString))
            {
                return View(model);
            }
            else
            {
                model = model.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
                return View(model);
            }
        }

        // GET: EventController/Delete/5
        public ActionResult DeleteFromCalendar(int id)
        {
            var model = _eventService.GetEventById(id);
            return View(model);
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFromCalendar(int eventToDeleteId, EventDto model)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                _eventService.DeleteEventFromCalendar(eventToDeleteId, loggedUserId);
                return RedirectToAction("MyEvents");
            }
            catch
            {
                return View();
            }
        }

        //TODO - 
        [Route("eventmembers/{id:int}")]
        public ActionResult EventMembers(int id)
        {
            EventMembersDto eventMembersDto = new EventMembersDto();
            var modelEvent = _eventService.GetEventById(id);
            eventMembersDto.Name = modelEvent.Name;
            eventMembersDto.Description = modelEvent.Description;
            eventMembersDto.Date = modelEvent.Date;
            eventMembersDto.Isopen = modelEvent.Isopen;

            eventMembersDto.EventUsers = _applicationUserEventService.GetUsersForEvent(id);

            return View(eventMembersDto);
        }

        public ActionResult MyEventsFinished(string searchString)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = _applicationUserEventService.GetMyEvents(loggedUserId);
            if (String.IsNullOrEmpty(searchString))
            {
                return View(model.Where(e => e.Date < DateTime.Now));
            }
            else
            {
                model = model.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) && e.Date < DateTime.Now).ToList();
                return View(model);
            }
        }
        public ActionResult MyEventsIncoming(string searchString)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = _applicationUserEventService.GetMyEvents(loggedUserId);
            if (String.IsNullOrEmpty(searchString))
            {
                return View(model.Where(e => e.Date >= DateTime.Now));
            }
            else
            {
                model = model.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) && e.Date >= DateTime.Now).ToList();
                return View(model);
            }
        }
    }
}
