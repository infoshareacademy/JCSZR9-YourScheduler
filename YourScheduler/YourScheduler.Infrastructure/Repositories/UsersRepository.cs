using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;

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

        //public ApplicationUser GetUserById(string id)
        //{
        //    var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
        //    return user;
        //}

        public List<ApplicationUser> GetUsersFromDataBase()
        {
            var users = new List<ApplicationUser>();   
            users=_dbContext.Users.ToList(); 
            return users;
        }

        public void UpdateUser(ApplicationUser updatedUser)
        {
            throw new NotImplementedException();
        }  
        
        public ApplicationUser GetUserByEmail(string email)
        {
            
              return _dbContext.ApplicationUsers.FirstOrDefault(x => x.Email == email);

        }

        public ApplicationUser GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        //public List<Event> GetEventsFromDataBase() 
        //{ 
        //  var events = new List<Event>();
        //  events = _dbContext.Events
        // .Where(e => e.UsersEvents.Any(ue => ue.UserId == 4a0b840d - 813a - 41ca - 8c03 - dddbc5bfbe3e))
        // .ToList();
        //   return events;
        //}
    }
}
