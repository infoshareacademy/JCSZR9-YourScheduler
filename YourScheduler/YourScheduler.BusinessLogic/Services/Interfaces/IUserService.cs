using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAllUsers();

        UserDto GetUserByEmail(string email);

        void AddUser(UserDto user);
        UserDto GetUserById(int id);
        void UpdateUser(UserDto userDtoUpdated);
    }
}
