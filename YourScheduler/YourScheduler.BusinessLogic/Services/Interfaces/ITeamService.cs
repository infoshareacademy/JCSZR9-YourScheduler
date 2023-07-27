using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface ITeamService
    {
        public void AddTeam(TeamDto teamDto);

        public List<TeamDto> GetAvailableTeams(int loggedUserId, string searchString);

        public TeamDto GetTeamById(int id);

        public void DeleteTeam(int id);

        public void DeleteTeamFromCalendar(int id, int userId);

        public void UpdateTeam(TeamDto teamDto);

        public void AddTeamForUser(int applicationUserId, int teamId);

        public List<TeamDto> GetMyTeams(int applicationUserId,string searchString);

        public List<UserDto> GetUsersForTeam(int teamid);
    }
}
