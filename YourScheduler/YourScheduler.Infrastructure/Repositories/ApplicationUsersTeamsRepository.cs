using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories
{
    internal class ApplicationUsersTeamsRepository : IApplicationUsersTeamsRepository
    {
        private readonly YourSchedulerDbContext _dbContext;
        public ApplicationUsersTeamsRepository(YourSchedulerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddTeamForUser(int applicationUserId, int teamId)
        {
            _dbContext.ApplicationUsersTeams.Add(new ApplicationUserTeam {ApplicationUserId= applicationUserId,TeamId=teamId});
        }
        public void SaveData()
        {
            _dbContext.SaveChanges();
        }

        public List<Team> GetTeamsForUser(int applicationUserId)
        {
            List<int> ids = new List<int>();
            List<Team> teams = new List<Team>();

            ids = _dbContext.ApplicationUsersTeams.Where(x => x.ApplicationUserId == applicationUserId).Select(x => x.TeamId).ToList();

            //foreach (var item in _dbContext.ApplicationUsersEvents)
            //{
            //    if (item.ApplicationUserId == applicationUserId)
            //    {
            //        ids.Add(item.EventId);
            //    }

            //}

            // events=_dbContext.Events.Where(x=>x.EventId==x.EventId).ToList();

            foreach (var teamId in ids)
            {
                var teamFromDataBase = _dbContext.Teams.FirstOrDefault(e => e.TeamId == teamId);
                teams.Add(teamFromDataBase);
            }


            return teams;

        }
    }
}
