using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.WebApplication.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;

        public EventController(IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }

        // GET: EventController
        [Authorize]
        public ActionResult Index(string searchString)
        {
            var userName = HttpContext.User.Identity.GetUserName();
            var user = _userService.GetUserByEmail(userName);
            var model = _eventService.GetAvailableEvents(user.Id);
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

        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            var model = _eventService.GetEventById(id);
            return View(model);
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
                var userName = HttpContext.User.Identity.GetUserName();
                var user = _userService.GetUserByEmail(userName);
                if (model != null)
                {
                    model.administratorId = user.Id;
                    _eventService.AddEvent(model);
                }
                return RedirectToAction("Index","User");
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _eventService.GetEventById(id);
            return View(model);
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventDto model)
        {
            try
            {
                _eventService.UpdateEvent(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _eventService.GetEventById(id);
            return View(model);
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EventDto model)
        {
            try
            {
                _eventService.DeleteEvent(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
