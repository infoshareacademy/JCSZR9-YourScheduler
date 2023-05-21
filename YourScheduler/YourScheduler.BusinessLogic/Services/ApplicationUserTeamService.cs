using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mapppers.Interfaces;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Services
{
    public class ApplicationUserTeamService : IApplicationUserTeamService
    {
        private readonly IApplicationUsersTeamsRepository _applicationUsersTeamsRepository;

        private readonly ITeamMapper _teamMapper;
        public ApplicationUserTeamService(IApplicationUsersTeamsRepository applicationUsersTeamsRepository, ITeamMapper teamMapper)
        {
            _applicationUsersTeamsRepository = applicationUsersTeamsRepository;
            _teamMapper = teamMapper;
        }
        public void AddTeamForUser(int applicationUserId, int teamId)
        {
            _applicationUsersTeamsRepository.AddTeamForUser(applicationUserId, teamId);
            _applicationUsersTeamsRepository.SaveData();
        }

        public List<TeamDto> GetMyTeams(int applicationUserId)
        {
            List<TeamDto> teamDtos = new List<TeamDto>();
            var teamsFromDataBase=_applicationUsersTeamsRepository.GetTeamsForUser(applicationUserId);
            foreach (var team in teamsFromDataBase) 
            {
                var teamDto = _teamMapper.TeamToTeamDtoMap(team);
                teamDtos.Add(teamDto);
            }

            return teamDtos;
        }
    }
}
