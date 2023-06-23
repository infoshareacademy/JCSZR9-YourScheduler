using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface IAvailableTeamsViewService
    {
        public List<TeamDto> GetAvailableTeams(int id);
    }
}
