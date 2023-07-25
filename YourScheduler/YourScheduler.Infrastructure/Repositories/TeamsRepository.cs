using Microsoft.EntityFrameworkCore;
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

        public async Task AddTeamAsync(Team team)
        {
            await _dbContext.Teams.AddAsync(team);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Team>> GetAllExistedTeamsAsync()
        {
            return await _dbContext.Teams.ToListAsync();
        }

        public async Task<Team?> GetTeamByIdAsync(int id)
        {
            return await _dbContext.Teams.FirstOrDefaultAsync(t => t.TeamId == id);  
        }

        public async Task DeleteTeamByIdAsync(int id)
        {
            await _dbContext.Teams.Where(t => t.TeamId == id).ExecuteDeleteAsync();
            await _dbContext.ApplicationUsersTeams.Where(t => t.TeamId == id).ExecuteDeleteAsync();
        }

        public async Task DeleteTeamFromCalendarByIdAsync(int id, int userId)
        {
            await _dbContext.ApplicationUsersTeams.Where(x => x.TeamId == id && x.ApplicationUserId == userId).ExecuteDeleteAsync();
        }

        public async Task UpdateTeamAsync(Team teamToBase)
        {
            await _dbContext.Teams.Where(t => t.TeamId == teamToBase.TeamId).ExecuteUpdateAsync(setters => setters
            .SetProperty(t => t.Name, teamToBase.Name)
            .SetProperty(t => t.Description, teamToBase.Description));
        }

        public async Task AddTeamForUserAsync(int applicationUserId, int teamId)
        {
            await _dbContext.ApplicationUsersTeams.AddAsync(new ApplicationUserTeam { ApplicationUserId = applicationUserId, TeamId = teamId });
            await _dbContext.SaveChangesAsync();
        }
       

        public async Task<List<Team>> GetTeamsForUserAsync(int applicationUserId)
        {
            return await _dbContext.ApplicationUsersTeams.Where(x => x.ApplicationUserId == applicationUserId).Select(x => x.Team).ToListAsync();
        }

        public async Task<List<ApplicationUser>> GetApplicationUsersForTeamAsync(int teamId)
        {
            return await _dbContext.ApplicationUsersTeams.Where(x => x.TeamId == teamId).Select(x => x.ApplicationUser).ToListAsync();
        }

        public async Task<bool> CheckIfLoggedUserIsParticipantAsync(int loggedUserId, int teamId)
        {
            return await _dbContext.ApplicationUsersTeams.AnyAsync(e => e.ApplicationUserId == loggedUserId && e.TeamId == teamId);
        }
    }


}
