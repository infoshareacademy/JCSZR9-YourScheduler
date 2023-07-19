using YourScheduler.BusinessLogic.Mapppers.Interfaces;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Services
{
    public  class TeamService : ITeamService
    {
        private readonly ITeamsRepository _teamsRepository;

        private readonly ITeamMapper _teamMapper;

        private readonly IUserMapper _userMapper;
        public TeamService(ITeamsRepository teamsRepository,ITeamMapper teamMapper,IUserMapper userMapper)
        {
            _teamsRepository = teamsRepository;
            _teamMapper = teamMapper;
            _userMapper = userMapper;
        }

        public async Task AddTeamAsync(TeamDto teamDto)
        {
            var teamToDatabase=_teamMapper.TeamDtoToTeamMap(teamDto);
            await _teamsRepository.AddTeamAsync(teamToDatabase);
        }

        public async Task<List<TeamDto>> GetAvailableTeamsAsync(int loggedUserId, string searchString)
        {
            List<TeamDto> teamsDto = new List<TeamDto>();
            var teamsFromDataBase = await _teamsRepository.GetAllExistedTeamsAsync();

            foreach (var teamFromBase in teamsFromDataBase)
            {
                var team = _teamMapper.TeamToTeamDtoMap(teamFromBase);
                if (loggedUserId==teamFromBase.AdministratorId)
                {
                    team.CanLoggedUserDelete = true;
                    team.CanLoggedUserEdit = true;
                }
                team.IsLoggedUserParticipant = await _teamsRepository.CheckIfLoggedUserIsParticipantAsync(loggedUserId, team.Id);
                teamsDto.Add(team);
            }
            if (String.IsNullOrEmpty(searchString))
            {
                return teamsDto;
            }
            else
            {
                return teamsDto.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            
        }

        public async Task<TeamDto> GetTeamByIdAsync(int id,int loggedUserId)
        {
            var teamFromDataBase = await _teamsRepository.GetTeamByIdAsync(id);
            var teamDto= _teamMapper.TeamToTeamDtoMap(teamFromDataBase);
            if (teamDto.AdministratorId==loggedUserId)
            {
                teamDto.CanLoggedUserDelete = true;
                teamDto.CanLoggedUserEdit = true;
            }
            teamDto.IsLoggedUserParticipant = await _teamsRepository.CheckIfLoggedUserIsParticipantAsync(loggedUserId, teamDto.Id);
            return teamDto;
        }

        public async Task DeleteTeamAsync(int id)
        {
            await _teamsRepository.DeleteTeamByIdAsync(id);
        }

        public async Task DeleteTeamFromCalendarAsync(int id, int userId)
        {
            await _teamsRepository.DeleteTeamFromCalendarByIdAsync(id, userId);
        }

        public async Task UpdateTeamAsync(TeamDto teamDto)
        {
            var teamToBase = _teamMapper.TeamDtoToTeamMap(teamDto);
            await _teamsRepository.UpdateTeamAsync(teamToBase);
        }

        public async Task AddTeamForUserAsync(int applicationUserId, int teamId)
        {
            await _teamsRepository.AddTeamForUserAsync(applicationUserId, teamId);
        }

        public async Task<List<TeamDto>> GetMyTeamsAsync(int applicationUserId, string searchString)
        {
            List<TeamDto> myTeams = new List<TeamDto>();
            var teamsFromDataBase = await _teamsRepository.GetTeamsForUserAsync(applicationUserId);
            foreach (var team in teamsFromDataBase)
            {
                var teamDto = _teamMapper.TeamToTeamDtoMap(team);
                if (applicationUserId==team.AdministratorId)
                {
                    teamDto.CanLoggedUserDelete = true;
                    teamDto.CanLoggedUserEdit = true;

                }
                teamDto.IsLoggedUserParticipant = await _teamsRepository.CheckIfLoggedUserIsParticipantAsync(applicationUserId, teamDto.Id);
                myTeams.Add(teamDto);
            }
            if (String.IsNullOrEmpty(searchString))
            {
                return myTeams;
            }
            else
            {
                return myTeams.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
           
        }

        public async Task<List<UserDto>> GetUsersForTeamAsync(int teamtId)
        {
            List<UserDto> usersDtos = new List<UserDto>();
            var usersForTeam = await _teamsRepository.GetApplicationUsersForTeamAsync(teamtId);

            foreach (var user in usersForTeam)
            {
                var userDto = _userMapper.UserToUserDtoMapp(user);
                usersDtos.Add(userDto);
            }
            return usersDtos;
        }
    }
}
