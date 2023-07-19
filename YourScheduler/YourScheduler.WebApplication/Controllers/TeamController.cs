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
        public async Task<ActionResult> GetAllTeams(string searchString)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());

            var viewModel = await _teamService.GetAvailableTeamsAsync(loggedUserId, searchString);
           
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
        public async Task<ActionResult> Details(int id)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _teamService.GetTeamByIdAsync(id, loggedUserId);
         
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
        public async Task<ActionResult> Create(TeamDto model)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                if (model != null)
                {
                    model.AdministratorId = loggedUserId;
                    await _teamService.AddTeamAsync(model);
                }
                return RedirectToAction("Index", "User");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
           
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _teamService.GetTeamByIdAsync(id, loggedUserId);
            if (model.AdministratorId == loggedUserId)
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
        public async Task<ActionResult> Edit(int id, TeamDto model)
        {
            var userName = HttpContext.User.Identity.GetUserName();
            var user = _userService.GetUserByEmail(userName);
            model.AdministratorId = user.Id;
            try
            {
                await _teamService.UpdateTeamAsync(model);
                return RedirectToAction("GetAllTeams");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _teamService.GetTeamByIdAsync(id,loggedUserId);
            if (model.AdministratorId == loggedUserId)
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
        public async Task<ActionResult> Delete(int id, TeamDto model)
        {
            try
            {
                await _teamService.DeleteTeamAsync(id);
                return RedirectToAction("GetAllTeams");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> DeleteFromCalendar(int id)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _teamService.GetTeamByIdAsync(id, loggedUserId);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteFromCalendar(int id, TeamDto model)
        {
            try
            {             
                var userId = int.Parse(User.Identity.GetUserId());
                await _teamService.DeleteTeamFromCalendarAsync(id, userId);
                return RedirectToAction("GetUserTeams");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> GetUserTeams(string searchString)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _teamService.GetMyTeamsAsync(loggedUserId, searchString);
            return View(model);
        }

        [Route("addthisteam/{id:int}")]
        public async Task<ActionResult> AddThisTeam(int id)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _teamService.GetTeamByIdAsync(id, loggedUserId);
            return View(model);

        }

        // POST: ApplicationUserEventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("addthisteam/{id:int}")]
        public async Task<ActionResult> AddThisTeam(TeamDto model)
        {
            try
            {
                // var userName = HttpContext.User.Identity.GetUserName();
                var userId = int.Parse(User.Identity.GetUserId());

                //  var user = _userService.GetUserByEmail(userName);
                await _teamService.AddTeamForUserAsync(userId, model.Id);
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
        public async Task<ActionResult> TeamMembers(int id)
        {
            TeamMembersDto teamMembersDto = new TeamMembersDto();
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var modelTeam = await _teamService.GetTeamByIdAsync(id, loggedUserId);
            teamMembersDto.Name = modelTeam.Name;
            teamMembersDto.Description = modelTeam.Description;

            teamMembersDto.TeamUsers = await _teamService.GetUsersForTeamAsync(id);

            return View(teamMembersDto);
        }
    }
}
