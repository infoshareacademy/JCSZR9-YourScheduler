using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.WebApplication.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: EventController
        [Authorize]
        public ActionResult GetAllEvents(string searchString)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = _eventService.GetAvailableEvents(loggedUserId, searchString);
                return View(model);
            }
            catch
            {
                //log - TODO
                return View();
            }
        }

        public ActionResult GetUserEvents(string searchString)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = _eventService.GetMyEvents(loggedUserId, searchString);
            return View(model);
        }

        // GET: ApplicationUserEventController/Delete/5
        [Route("addthisevent/{id:int}")]
        public ActionResult AddThisEvent(int id)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = _eventService.GetEventById(id, loggedUserId);
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
                _eventService.AddEventForUser(loggedUserId, eventToAddId);
                return RedirectToAction(nameof(GetAllEvents));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = _eventService.GetEventById(id, loggedUserId);
                return View(model);
            }
            catch
            {
                //log - TODO
                return View();
            }
        }

        // GET: EventController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(EventDto model)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                if (model != null)
                {
                    model.AdministratorId = loggedUserId;
                    _eventService.AddEvent(model);
                }
                return RedirectToAction(nameof(GetAllEvents));
            }
            catch
            {
                //log - TODO
                return View();
            }
        }

        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = _eventService.GetEventById(id, loggedUserId);
                return View(model);
            }
            catch
            {
                //log - TODO
                return View();
            }
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventDto model)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                model.AdministratorId = loggedUserId;
                _eventService.UpdateEvent(model);
                return RedirectToAction(nameof(GetAllEvents));
            }
            catch
            {
                //log - TODO
                return View();
            }
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = _eventService.GetEventById(id, loggedUserId);
                return View(model);
            }
            catch
            {
                //log - TODO
                return View();
            }
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EventDto model)
        {
            try
            {
                _eventService.DeleteEvent(id);
                return RedirectToAction(nameof(GetAllEvents));
            }
            catch
            {
                //log - TODO
                return View();
            }
        }

        // GET: EventController/Delete/5
        public ActionResult DeleteFromCalendar(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = _eventService.GetEventById(id, loggedUserId);
                return View(model);
            }
            catch
            {
                //log - TODO
                return View();
            }
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
                return RedirectToAction(nameof(GetUserEvents));
            }
            catch
            {
                //log - TODO
                return View();
            }
        }

        [Route("eventmembers/{id:int}")]
        public ActionResult EventMembers(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var eventMembersDto = _eventService.GetEventMembersDto(id, loggedUserId);
                return View(eventMembersDto);
            }
            catch
            {
                //log - TODO
                return View();
            }
        }
    }
}
