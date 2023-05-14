using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using YourScheduler.BusinessLogic.Models;
using YourScheduler.BusinessLogic.Services;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _signInManager;
        public UserController(IUserService userService, Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
          
        }
        // GET: UserController

        //[Authorize]
        public async Task<ActionResult> Index()
        {
            var userName = HttpContext.User.Identity.GetUserName();
           
            
            var model = _userService.GetUserByEmail(userName);
            return View(model);
        }

        // GET: UserController/Details/5
      //  [Route("details/{id:int}")]
        public ActionResult Details()
        {
            return RedirectToAction("Create","Event");
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        [Route("edit/{id:int}")]
        public ActionResult Edit(string id)
        {
            var model = _userService.GetUserById(id);
            return View(model);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Route("edit/{id:int}")]
        public ActionResult Edit(int id, UserDto userDto)
        {
            try
            {
                _userService.UpdateUser(userDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error of editing user");
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
