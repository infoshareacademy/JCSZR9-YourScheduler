using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Mapppers.Interfaces
{
    public interface IUserMapper
    {
        ApplicationUser UserDtoToUserMap(UserDto userDto);
        UserDto UserToUserDtoMapp(ApplicationUser user);
    }
}