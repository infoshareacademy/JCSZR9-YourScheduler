using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace YourScheduler.BusinessLogic.Services
{
    public class AvailableTeamsViewService : IAvailableTeamsViewService
    {
        private readonly ITeamService _teamService;
        private readonly IUserService _userService;
        public readonly IApplicationUserTeamService _applicationUserTeamService;
        public AvailableTeamsViewService(ITeamService teamService, IUserService userService, IApplicationUserTeamService applicationUserTeamService)
        {
            _teamService = teamService;
            _userService = userService;
            _applicationUserTeamService = applicationUserTeamService;
        }

        public List<TeamDto> GetAvailableTeams(int id)
        {

            List<TeamDto> availableTeams = new List<TeamDto>();
            var teams1 = _applicationUserTeamService.GetMyTeams(id);
            var teams2 = _teamService.GetAllExistedTeams();
            var teams3 = teams2;
            for (int i = 0; i < teams2.Count; i++)
            {
                for (int j = 0; j < teams1.Count; j++)
                {
                    if (teams2[i].Id == teams1[j].Id)
                    {
                        teams2.Remove(teams2[i]);
                    }
                }
            }

            availableTeams = teams2;
            return availableTeams;
        }


    }
}
