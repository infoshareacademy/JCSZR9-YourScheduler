using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mappers;
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

        private readonly IUserMapper _userMapper;
        public TeamService(ITeamsRepository teamserepository,ITeamMapper teamMapper,IUserMapper userMapper)
        {
            _teamsRepository = teamserepository;
            _teamMapper = teamMapper;
            _userMapper = userMapper;
        }

        public void AddTeam(TeamDto teamDto)
        {
            var teamToDatabase=_teamMapper.TeamDtoToTeamMap(teamDto);
            _teamsRepository.AddTeam(teamToDatabase);
            _teamsRepository.SaveData();
        }

        public List<TeamDto> GetAvailableTeams(int loggedUserId, string searchString)
        {
            List<TeamDto> teamsDto = new List<TeamDto>();
            var teamsFromDataBase = _teamsRepository.GetAllExistedTeams();

            foreach (var teamFromBase in teamsFromDataBase)
            {
                var team = _teamMapper.TeamToTeamDtoMap(teamFromBase);
                if (loggedUserId==teamFromBase.AdministratorId)
                {
                    team.CanLoggedUserDelete = true;
                    team.CanLoggedUserEdit = true;
                }
                team.IsLoggedUserParticipant = _teamsRepository.CheckIfLoggedUserIsParticipant(loggedUserId, team.Id);
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

        public void AddTeamForUser(int applicationUserId, int teamId)
        {
            _teamsRepository.AddTeamForUser(applicationUserId, teamId);
            _teamsRepository.SaveData();
        }

        public List<TeamDto> GetMyTeams(int applicationUserId, string searchString)
        {
            List<TeamDto> myTeams = new List<TeamDto>();
            var teamsFromDataBase = _teamsRepository.GetTeamsForUser(applicationUserId);
            foreach (var team in teamsFromDataBase)
            {
                var teamDto = _teamMapper.TeamToTeamDtoMap(team);
                if (applicationUserId==team.AdministratorId)
                {
                    teamDto.CanLoggedUserDelete = true;
                    teamDto.CanLoggedUserEdit = true;

                }
                teamDto.IsLoggedUserParticipant = _teamsRepository.CheckIfLoggedUserIsParticipant(applicationUserId, teamDto.Id);
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

        public List<UserDto> GetUsersForTeam(int teamtId)
        {
            List<UserDto> usersDtos = new List<UserDto>();
            var usersForTeam = _teamsRepository.GetApplicationUsersForTeam(teamtId);

            foreach (var user in usersForTeam)
            {
                var userDto = _userMapper.UserToUserDtoMapp(user);
                usersDtos.Add(userDto);
            }
            return usersDtos;
        }
    }
}
