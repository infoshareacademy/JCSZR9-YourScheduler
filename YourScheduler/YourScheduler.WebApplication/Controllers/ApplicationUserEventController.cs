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
        public ActionResult AddThisEvent(int id)
        {
            var model = _eventService.GetEventById(id);
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
            var model = _applicationUserEventService.GetMyEvents(loggedUserId, searchString);
            return View(model);
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
        public ActionResult DeleteFromCalendar(int id, EventDto model)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                _eventService.DeleteEventFromCalendar(id, loggedUserId);
                return RedirectToAction("MyEvents");
            }
            catch
            {
                return View();
            }
        }

        [Route("eventmembers/{id:int}")]
        public ActionResult EventMembers(int id)
        {
            var eventMembersDto = _applicationUserEventService.GetEventMembersDto(id);
            return View(eventMembersDto);
        }

        public ActionResult MyEventsFinished(string searchString)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = _applicationUserEventService.GetMyEvents(loggedUserId, searchString);
            return View(model);
        }

        public ActionResult MyEventsIncoming(string searchString)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = _applicationUserEventService.GetMyEvents(loggedUserId, searchString);
            return View(model);
        }
    }
}
