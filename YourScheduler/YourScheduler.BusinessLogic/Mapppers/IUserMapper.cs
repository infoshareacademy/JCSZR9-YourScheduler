using YourScheduler.BusinessLogic.Models;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Mappers
{
    public interface IUserMapper
    {
        ApplicationUser UserDtoToUserMap(UserDto userDto);
        UserDto UserToUserDtoMapp(ApplicationUser user);
    }
}