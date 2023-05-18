using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories
{
    public interface ITeamsRepository
    {
        List<Team> GetAvailableTeams();

        public void AddTeam(Team team);

        public void SaveData();

        public Team GetTeamById(int id);

    }
}
