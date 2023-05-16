using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models;

namespace YourScheduler.BusinessLogic.Services
{
    public interface IUserService
    {
         List<UserDto> GetAllUsers();

         UserDto GetUserByEmail(String email);

         void AddUser(UserDto user);
         Task<UserDto> GetUserById(string id);
         void UpdateUser(UserDto userDtoUpdated);
    }
}
