using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.WebApplication.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IUserService _userService;
   

        public TeamController(ITeamService teamService, IUserService userService)
        {
            _teamService = teamService;
            _userService = userService;
           

        }
        // GET: TeamController
        [Authorize]
        public ActionResult GetAllTeams(string searchString)
        {
            var loggedUserId =int.Parse(User.Identity.GetUserId());
           



            var viewModel = _teamService.GetAvailableTeams(loggedUserId, searchString);
           
            if (String.IsNullOrEmpty(searchString))
            {
                return View(viewModel);
            }
            else
            {

                var allTeams2 = viewModel.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
                return View(allTeams2);
            }
        }

        // GET: TeamController/Details/5
        public ActionResult Details(int id)
        {
            var userNameLogged = HttpContext.User.Identity.GetUserName();
            var user = _userService.GetUserByEmail(userNameLogged);
            var model = _teamService.GetTeamById(id);
         
            return View(model);
        }

        // GET: TeamController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(TeamDto model)
        {
            try
            {
                var userName = HttpContext.User.Identity.GetUserName();
                var user = _userService.GetUserByEmail(userName);
                if (model != null)
                {
                    model.AdministratorId = user.Id;
                    _teamService.AddTeam(model);
                }
                return RedirectToAction("Index", "User");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _teamService.GetTeamById(id);
            var userName = HttpContext.User.Identity.GetUserName();
            var user = _userService.GetUserByEmail(userName);
            if (model.AdministratorId == user.Id)
            {
                return View(model);
            }
            else
            {
                return View("EditError");
            }

        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeamDto model)
        {
            var userName = HttpContext.User.Identity.GetUserName();
            var user = _userService.GetUserByEmail(userName);
            model.AdministratorId = user.Id;
            try
            {
                _teamService.UpdateTeam(model);
                return RedirectToAction("MyTeams","ApplicationUserTeam");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Delete/5
        public ActionResult Delete(int id)
        {
            var userName = HttpContext.User.Identity.GetUserName();
            var user = _userService.GetUserByEmail(userName);
            var model = _teamService.GetTeamById(id);
            if (model.AdministratorId == user.Id)
            {
                return View(model);
            }
            else
            {
                return View("DeleteError");
            }

        }

        // POST: TeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TeamDto model)
        {
            try
            {
                _teamService.DeleteTeam(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
                //  var userName = HttpContext.User.Identity.GetUserName();
                // var user = _userService.GetUserByEmail(userName);
                var userId = int.Parse(User.Identity.GetUserId());
                _teamService.DeleteTeamFromCalendar(id, userId);
                return RedirectToAction("GetUserTeams");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetUserTeams(string searchString)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = _teamService.GetMyTeams(loggedUserId, searchString);
            return View(model);
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
                // var userName = HttpContext.User.Identity.GetUserName();
                var userId = int.Parse(User.Identity.GetUserId());

                //  var user = _userService.GetUserByEmail(userName);
                _teamService.AddTeamForUser(userId, model.Id);
                return RedirectToAction(nameof(GetAllTeams));
            }
            catch (Exception ex)
            {
                return View("AddThisTeamError");
            }
            finally
            {

            }

        }

        

        [Route("teammembers/{id:int}")]
        public ActionResult TeamMembers(int id)
        {
            TeamMembersDto teamMembersDto = new TeamMembersDto();
            var modelTeam = _teamService.GetTeamById(id);
            teamMembersDto.Name = modelTeam.Name;
            teamMembersDto.Description = modelTeam.Description;

            teamMembersDto.TeamUsers = _teamService.GetUsersForTeam(id);

            return View(teamMembersDto);
        }
    }
}
