using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.BusinessLogic
{
    public class UserService
    {
        public List<User> userList = CSVManager.GetUsers();

        public User GetById(Guid id)
        {
            var user = userList.FirstOrDefault(u => u.Id == id);
            return user;
        }
        public void AddNewUser(User user)
        {
            userList.Add(user);
        }
        public void UpdateUserDisplayName(Guid id, string displayName)
        {
            var user = GetById(id);
            user.DisplayName= displayName;
        }
        public void UpdateUserEmail(Guid id, string email)
        {
            var user = GetById(id);
            user.Email= email;
        }
        public void UpdateUserPassword(Guid id, string password)
        {
            var user = GetById(id);
            user.Password= password;
        }


    }
}
