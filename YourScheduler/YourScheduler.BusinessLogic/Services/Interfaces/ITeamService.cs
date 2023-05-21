using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models;

namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface ITeamService
    {
        public void AddTeam(TeamDto teamDto);

        public List<TeamDto> GetAvailableTeams();

        public TeamDto GetTeamById(int id);
    }
}
