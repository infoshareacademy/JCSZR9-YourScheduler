using System.Linq;
using YourScheduler.BusinessLogic;
using YourScheduler.WebApplication.Models;

namespace YourScheduler.WebApplication.Services
{
    public class UsersServiceForView
    {
        UserService _userService = new UserService();
        public List<UserModel> MapToMvc()
        {
            var modelUsers = _userService.GetUsers();

            List<UserModel> users = new List<UserModel>();
            foreach (var item in modelUsers)
            {

                UserModel userModel = new UserModel();
                userModel.Id = item.Id;
                userModel.Name = item.Name;
                userModel.Email = item.Email;
                userModel.Password = item.Password;
                userModel.Displayname = item.Displayname;
                users.Add(userModel);
            }

            return users;
        }

        public YourScheduler.BusinessLogic.Models.User  MapToModel(UserModel userModel) 
        {
            YourScheduler.BusinessLogic.Models.User user = new YourScheduler.BusinessLogic.Models.User();
            
            user.Name = userModel.Name;
            user.Surname = userModel.Surname;
            user.Displayname = userModel.Displayname;
            user.Email = userModel.Email;
            user.Password = userModel.Password;
            
              

            return user;
        }

        public void AddUser(UserModel userModel) 
        {
           // YourScheduler.BusinessLogic.Models.User user = MapToModel(userModel);
            _userService.AddUserAsync(MapToModel(userModel));

        }

        public YourScheduler.WebApplication.Models.UserModel GetUserById(int id) 
        {
           var users = MapToMvc();
           var user= users.FirstOrDefault(u=>u.Id==id);
           return user;
        }
    }
}

