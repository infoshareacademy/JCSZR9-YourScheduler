using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourScheduler.BusinessLogic;
using YourScheduler.BusinessLogic.Models;
using YourScheduler.BusinessLogic.Services;

namespace YourScheduler.WebApplication.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        // YourSchedulerContext yourSchedulerContext=new YourSchedulerContext();
        // private readonly UsersServiceForView _userService;

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: UserController
        [Authorize]
        public ActionResult Index()
        {
            //UserServiceForView userService = new UserServiceForView();
            //  var model= _userService.MapToMvc();
            var model=_userService.GetAllUsers();
            return View(model);
        }

       // GET: UserController/Details/5
       
        [Route("details/{id:int}")]
        public ActionResult Details(int id)
        {
            //var model=_userService.GetUserById(id);
            return View();
        }

        // GET: UserController/Create
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }


        // POST: UserController/Create
        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDto user)
        {

            //UsersServiceForView userService = new UsersServiceForView();
            try
            {
                _userService.AddUser(user);   
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [Route("edit/{id:int}")]
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

        // GET: UserController/Delete/5
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [Route("delete/{id:int}")]
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
