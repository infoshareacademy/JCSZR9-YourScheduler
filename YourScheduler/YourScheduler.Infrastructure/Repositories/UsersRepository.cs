﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly YourSchedulerDbContext _dbContext;

        public UsersRepository(YourSchedulerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(ApplicationUser user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

      

        public List<ApplicationUser> GetUsersFromDataBase()
        {
            var users = new List<ApplicationUser>();   
            users = _dbContext.Users.ToList();

            return users;
        }

        public void UpdateUser(ApplicationUser updatedUser)
        {
            throw new NotImplementedException();
        }  
        
        public  ApplicationUser GetUserByEmail(string email)
        {
         
              return  _dbContext.ApplicationUsers.FirstOrDefault(x => x.Email == email);

        }

        public async  Task<ApplicationUser> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

      
    }
}
