using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models;

namespace YourScheduler.BusinessLogic.Services
{
    public interface IApplicationUserTeamService
    {
        public void AddTeamForUser(int applicationUserId, int teamId);

        public List<TeamDto> GetMyTeams(int applicationUserId);
    }
}
