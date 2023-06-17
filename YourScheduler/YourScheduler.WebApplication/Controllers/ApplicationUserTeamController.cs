using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.WebApplication.Controllers
{
    public class ApplicationUserTeamController : Controller
    {
        private readonly IUserService _userService;
        private readonly IApplicationUserTeamService _applicationUserTeamService;
        private readonly ITeamService _teamService;
        public ApplicationUserTeamController(IApplicationUserTeamService applicationUserTeamService,ITeamService teamService, IUserService userService)
        {

            _applicationUserTeamService = applicationUserTeamService;
            _teamService = teamService;
            _userService = userService; 

        }
        // GET: ApplicationUserTeamController1
       

        // GET: ApplicationUserTeamController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicationUserTeamController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUserTeamController1/Create
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

        // GET: ApplicationUserTeamController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationUserTeamController1/Edit/5
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

        // GET: ApplicationUserTeamController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicationUserTeamController1/Delete/5
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

        [Route("addthisteam/{id:int}")]
        public ActionResult AddThisTeam(int id)
        {

            var model = _teamService.GetTeamById(id);
            return View(model);

        }

        // POST: ApplicationUserEventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("addthisteam/{id:int}")]
        public ActionResult AddThisTeam(TeamDto model)
        {
            try
            {
                var userName = HttpContext.User.Identity.GetUserName();


                var user = _userService.GetUserByEmail(userName);
                _applicationUserTeamService.AddTeamForUser(user.Id, model.Id);
                return RedirectToAction("Index", "Team");
            }
            catch (Exception ex)
            {
                return View("AddThisTeamError");
            }
            finally
            {

            }

        }


        public ActionResult MyTeams(string searchString)
        {
            var userName = HttpContext.User.Identity.GetUserName();
            var user = _userService.GetUserByEmail(userName);
            var model = _applicationUserTeamService.GetMyTeams(user.Id);
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

        [Route("teammembers/{id:int}")]
        public ActionResult TeamMembers(int id)
        {
            TeamMembersDto teamMembersDto = new TeamMembersDto();
            var modelTeam = _teamService.GetTeamById(id);
            teamMembersDto.Name = modelTeam.Name;
            teamMembersDto.Description = modelTeam.Description;
            
            teamMembersDto.TeamUsers = _applicationUserTeamService.GetUsersForTeam(id);
           
            return View(teamMembersDto);        
        }

        public ActionResult DeleteFromCalendar(int id)
        {
            var model = _teamService.GetTeamById(id);
            return View(model);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFromCalendar(int id, TeamDto model)
        {
            try
            {
                var userName = HttpContext.User.Identity.GetUserName();
                var user = _userService.GetUserByEmail(userName);
                _teamService.DeleteTeamFromCalendar(id, user.Id);
                return RedirectToAction("MyTeams");
            }
            catch
            {
                return View();
            }
        }
    }
}
