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
        public ActionResult Index()
        {
            var model = _eventService.GetAvailableEvents();
            return View(model);
        }

        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            return View();
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
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
            return View();
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
