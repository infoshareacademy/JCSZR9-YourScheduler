using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.WebApplication.Controllers
{
    public class ApplicationUserEventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IApplicationUserEventService _applicationUserEventService;
        private readonly IUserService _userService;
        // private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _signInManager;
        public ApplicationUserEventController(IEventService eventService, IApplicationUserEventService applicationUserEventService, IUserService userService)
        {

            _eventService = eventService;
            _applicationUserEventService = applicationUserEventService;
            _userService = userService;

            // _signInManager = signInManager;

        }
        // GET: ApplicationUserEventController
        [Authorize]
        public ActionResult Index()
        {
            var model = _eventService.GetAvailableEvents();
            return View(model);

        }

        // GET: ApplicationUserEventController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicationUserEventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUserEventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ApplicationUserEventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationUserEventController/Edit/5
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
                var userName = HttpContext.User.Identity.GetUserName();


                var user = _userService.GetUserByEmail(userName);
                _applicationUserEventService.AddEventForUser(user.Id, model.Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
                // return View"dupa";
                //return View("Error");
                // throw ex;
                // return View("Error");
                // ex.ToString();
                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Error", "Home");
            }
            finally
            {

            }

        }

        //[HttpPost]
        // [ValidateAntiForgeryToken]
        //[Route("applicationuserevent/myevents")]
        // [Authorize]
        public ActionResult MyEvents()
        {
            var userName = HttpContext.User.Identity.GetUserName();
            var user = _userService.GetUserByEmail(userName);
            var model = _applicationUserEventService.GetMyEvents(user.Id);
            return View(model);
            //var model = _eventService.GetAvailableEvents();
            //return View(model);
        }

    }
}
