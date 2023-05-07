using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models;


namespace YourScheduler.BusinessLogic
{
    public class UserService
    {
        public List<User> userList = CSVManager.GetUsers();

        public YourScheduler.BusinessLogic.Models.User GetById(int id)
        {
            var user = GetUsers().FirstOrDefault(user => user.Id == id);
            return user;
        }
        //public void AddNewUser(User user)
        //{
        //    userList.Add(user);
        //}
        //public void UpdateUserDisplayName(Guid id, string displayName)
        //{
        //    var user = GetById(id);
        //    user.DisplayName= displayName;
        //}
        //public void UpdateUserEmail(Guid id, string email)
        //{
        //    var user = GetById(id);
        //    user.Email= email;
        //}
        //public void UpdateUserPassword(Guid id, string password)
        //{
        //    var user = GetById(id);
        //    user.Password= password;
        //}

       

        public void AddUserAsync(YourScheduler.BusinessLogic.Models.User user)
        {
            using (var context = new YourSchedulerContext())
            {
                context.Users.Add(user);
                context.SaveChanges();

            }
        }

        public List<YourScheduler.BusinessLogic.Models.User> GetUsers()
        {
            var users = new List<YourScheduler.BusinessLogic.Models.User>();

            using (var context = new YourSchedulerContext())
            {
                users = context.Users.ToList();              
                
            }


            return users;
        }

       
    }
}
