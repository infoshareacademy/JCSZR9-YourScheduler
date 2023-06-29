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
        public async Task<ActionResult> GetAllEvents(string searchString)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = await _eventService.GetAvailableEventsAsync(loggedUserId, searchString);
                return View(model);
            }
            catch
            {
                //log - TODO
                return View();
            }
        }

        public async Task<ActionResult> GetUserEvents(string searchString)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _eventService.GetMyEventsAsync(loggedUserId, searchString);
            return View(model);
        }

        // GET: ApplicationUserEventController/Delete/5
        [Route("addthisevent/{id:int}")]
        public async Task<ActionResult> AddThisEvent(int id)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _eventService.GetEventByIdAsync(id, loggedUserId);
            return View(model);
        }

        // POST: ApplicationUserEventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("addthisevent/{id:int}")]
        public async Task<ActionResult> AddThisEvent(EventDto model)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var eventToAddId = model.Id;
                await _eventService.AddEventForUserAsync(loggedUserId, eventToAddId);
                return RedirectToAction(nameof(GetAllEvents));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = await _eventService.GetEventByIdAsync(id, loggedUserId);
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
        public async Task<ActionResult> Create(EventDto model)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                if (model != null)
                {
                    await _eventService.AddEventAsync(model, loggedUserId);
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
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = await _eventService.GetEventByIdAsync(id, loggedUserId);
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
        public async Task<ActionResult> Edit(int id, EventDto model)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                model.AdministratorId = loggedUserId;
                await _eventService.UpdateEventAsync(model);
                return RedirectToAction(nameof(GetAllEvents));
            }
            catch
            {
                //log - TODO
                return View();
            }
        }

        // GET: EventController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = await _eventService.GetEventByIdAsync(id, loggedUserId);
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
        public async Task<ActionResult> Delete(int id, EventDto model)
        {
            try
            {
                await _eventService.DeleteEventAsync(id);
                return RedirectToAction(nameof(GetAllEvents));
            }
            catch
            {
                //log - TODO
                return View();
            }
        }

        // GET: EventController/Delete/5
        public async Task<ActionResult> DeleteFromCalendar(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = await _eventService.GetEventByIdAsync(id, loggedUserId);
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
        public async Task<ActionResult> DeleteFromCalendar(int id, EventDto model)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                await _eventService.DeleteEventFromCalendarAsync(id, loggedUserId);
                return RedirectToAction(nameof(GetUserEvents));
            }
            catch
            {
                //log - TODO
                return View();
            }
        }

        [Route("eventmembers/{id:int}")]
        public async Task<ActionResult> EventMembers(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var eventMembersDto = await _eventService.GetEventMembersDtoAsync(id, loggedUserId);
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
