using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories.Interfaces
{
    public interface ITeamsRepository
    {
        List<Team> GetAvailableTeams();

        public void AddTeam(Team team);

        public void SaveData();

        public Team GetTeamById(int id);

        public void DeleteTeamById(int id);

        public void DeleteTeamFromCalendarById(int id, int userId);

        public void UpdateTeam(Team teamToBase);

    }
}
