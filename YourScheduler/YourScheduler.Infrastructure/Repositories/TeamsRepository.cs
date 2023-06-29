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

        public List<Team> GetAllExistedTeams()
        {
            List<Team> teams = new List<Team>();
            teams = _dbContext.Teams.ToList();
            return teams;
        }

        public Team GetTeamById(int id)
        {
            return _dbContext.Teams.FirstOrDefault(t=>t.TeamId==id);  
        }

        public void DeleteTeamById(int id)
        {
            var teamToDelete = GetTeamById(id);
            if (teamToDelete != null)
            {
                _dbContext.Teams.Remove(teamToDelete);
                var applicationUserTeamsToDelete = _dbContext.ApplicationUsersTeams.Where(x => x.TeamId == teamToDelete.TeamId);
                _dbContext.ApplicationUsersTeams.RemoveRange(applicationUserTeamsToDelete);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteTeamFromCalendarById(int id, int userId)
        {
            var teamToDelete = GetTeamById(id);
            if (teamToDelete != null)
            {
                var applicationUsersTeamsToDelete = _dbContext.ApplicationUsersTeams.SingleOrDefault(x => x.TeamId ==teamToDelete.TeamId && x.ApplicationUserId == userId);
                _dbContext.ApplicationUsersTeams.Remove(applicationUsersTeamsToDelete);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateTeam(Team teamToBase)
        {
            var teamToUpdate = _dbContext.Teams.SingleOrDefault(e => e.TeamId == teamToBase.TeamId);
            if (teamToUpdate != null)
            {
                teamToUpdate.Name = teamToBase.Name;
                teamToUpdate.Description = teamToBase.Description;
                
                _dbContext.SaveChanges();
            }
        }

        public void AddTeamForUser(int applicationUserId, int teamId)
        {
            _dbContext.ApplicationUsersTeams.Add(new ApplicationUserTeam { ApplicationUserId = applicationUserId, TeamId = teamId });
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

        public bool CheckIfLoggedUserIsParticipant(int loggedUserId, int teamId)
        {
            var isLoggedUserParticipant = _dbContext.ApplicationUsersTeams.Any(e => e.ApplicationUserId == loggedUserId && e.TeamId == teamId);
            return isLoggedUserParticipant;
        }
    }


}
