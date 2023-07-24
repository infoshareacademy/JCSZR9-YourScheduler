﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories.Interfaces
{
    public interface IApplicationUsersTeamsRepository
    {
        void AddTeamForUser(int applicationUserId, int teamId);

        public void SaveData();

        List<Team> GetTeamsForUser(int applicationUserId);

        public List<ApplicationUser> GetApplicationUsersForTeam(int teamId);

    }
}