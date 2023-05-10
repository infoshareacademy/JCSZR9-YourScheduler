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
        public List<UserDto> GetAllUsers();

        public void AddUser(UserDto user);
        public UserDto GetUserById(Guid id);
        public void UpdateUser(UserDto userDtoUpdated);
    }
}
