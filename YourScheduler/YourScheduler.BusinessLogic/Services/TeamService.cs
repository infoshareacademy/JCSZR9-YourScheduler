using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mapppers;
using YourScheduler.BusinessLogic.Mapppers.Interfaces;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Repositories;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamsRepository _teamsRepository;

        private readonly ITeamMapper _teamMapper;
        public TeamService(ITeamsRepository teamserepository,ITeamMapper teamMapper)
        {
            _teamsRepository = teamserepository;
            _teamMapper = teamMapper;   
        }

        public void AddTeam(TeamDto teamDto)
        {
            var teamToDatabase=_teamMapper.TeamDtoToTeamMap(teamDto);
            _teamsRepository.AddTeam(teamToDatabase);
            _teamsRepository.SaveData();
        }

        public List<TeamDto> GetAvailableTeams()
        {
            List<TeamDto> teamDtos = new List<TeamDto>();
            var teamsFromDataBase = _teamsRepository.GetAvailableTeams();

            foreach (var teamFromBase in teamsFromDataBase) 
            {
                var team = _teamMapper.TeamToTeamDtoMap(teamFromBase);
                teamDtos.Add(team);
            }
            return teamDtos;
        }

        public TeamDto GetTeamById(int id)
        {
            var teamFromDataBase = _teamsRepository.GetTeamById(id);
            return _teamMapper.TeamToTeamDtoMap(teamFromDataBase);
        }

        public void DeleteTeam(int id)
        {
            _teamsRepository.DeleteTeamById(id);
        }

        public void DeleteTeamFromCalendar(int id, int userId)
        {
            _teamsRepository.DeleteTeamFromCalendarById(id, userId);
        }

        public void UpdateTeam(TeamDto teamDto)
        {
            var teamToBase = _teamMapper.TeamDtoToTeamMap(teamDto);
            _teamsRepository.UpdateTeam(teamToBase);
        }
    }
}
