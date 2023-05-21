using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Mappers
{
    public class UserMapper : IUserMapper
    {
        public UserDto UserToUserDtoMapp(ApplicationUser user)
        {
            UserDto userDto = new UserDto()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Displayname = user.Displayname,
                Email = user.Email,
                // Password=user.Password,               
            };
            return userDto;
        }

        public ApplicationUser UserDtoToUserMap(UserDto userDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Surname = userDto.Surname,
                Displayname = userDto.Displayname,
                Email = userDto.Email,
                //Password=userDto.Password,
            };
            return user;
        }
    }
}
