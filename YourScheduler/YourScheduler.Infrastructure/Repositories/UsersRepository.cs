using System;
using System.Collections.Generic;
using System.Linq;
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

        public ApplicationUser GetUserById(Guid id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

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
    }
}
