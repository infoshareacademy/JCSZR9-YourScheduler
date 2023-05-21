﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Mapppers
{
    public interface ITeamMapper
    {
        TeamDto TeamToTeamDtoMap(Team team);
        Team TeamDtoToTeamMap(TeamDto teamDto);
    }
}
