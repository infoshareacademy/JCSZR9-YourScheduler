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

        public List<TeamDto> GetAvailableTeams();

        public TeamDto GetTeamById(int id);

        public void DeleteEvent(int id);

        public void DeleteTeamFromCalendar(int id, int userId);
    }
}
