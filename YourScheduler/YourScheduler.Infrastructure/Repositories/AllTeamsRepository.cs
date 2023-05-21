using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly YourSchedulerDbContext _dbContext;

        public TeamsRepository(YourSchedulerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTeam(Team team)
        {
            _dbContext.Teams.Add(team);
        }

        public void SaveData()
        {
            _dbContext.SaveChanges();
        }

        public List<Team> GetAvailableTeams()
        {
            List<Team> teams = new List<Team>();
            teams=_dbContext.Teams.ToList();
            return teams;
        }

        public Team GetTeamById(int id)
        {
            return _dbContext.Teams.FirstOrDefault(t=>t.TeamId==id);  
        }

    }
}
