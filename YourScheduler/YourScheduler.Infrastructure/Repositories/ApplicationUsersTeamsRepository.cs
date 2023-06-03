using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

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

            teams = _dbContext.ApplicationUsersTeams.Where(x => x.ApplicationUserId == applicationUserId).Select(x => x.Team).ToList();
            
            return teams;

        }

        public List<ApplicationUser> GetApplicationUsersForTeam(int teamId)
        {
            List<ApplicationUser> applicationUsers = new List<ApplicationUser>();
            applicationUsers = _dbContext.ApplicationUsersTeams.Where(x => x.TeamId == teamId).Select(x => x.ApplicationUser).ToList();
            return applicationUsers;
        }
    }
}
