﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        List<ApplicationUser> GetUsersFromDataBase();
        ApplicationUser GetUserById(int id);

        ApplicationUser GetUserByEmail(string email);

        public void AddUser(ApplicationUser user);
        public void UpdateUser(ApplicationUser updatedUser);
    }
}
