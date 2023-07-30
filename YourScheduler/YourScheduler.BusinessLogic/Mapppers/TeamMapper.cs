using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mapppers.Interfaces;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Mapppers
{
    public class TeamMapper : ITeamMapper
    {
        public Team TeamDtoToTeamMap(TeamDto teamDto)
        {
            Team team = new Team()
            {
                TeamId = teamDto.Id,
                Name = teamDto.Name,
                Description = teamDto.Description,
                AdministratorId = teamDto.AdministratorId,
            };
            if (teamDto.PicturePath is null)
            {
                return team;
            }
            else
            {
                team.PicturePath = teamDto.PicturePath;
            }
            return team;
        }

        public TeamDto TeamToTeamDtoMap(Team team)
        {
            TeamDto teamDto = new TeamDto()
            {
               Id=team.TeamId,
               Name = team.Name,
               Description = team.Description,
               AdministratorId = team.AdministratorId,            
            };
            if (team.PicturePath is null)
            {
                return teamDto;
            }
            else
            {
                teamDto.PicturePath = team.PicturePath;
            }
            return teamDto;
        }
    }
}
