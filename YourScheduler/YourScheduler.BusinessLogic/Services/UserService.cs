using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mapppers.Interfaces;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;



namespace YourScheduler.BusinessLogic.Services
{
    public class UserService :IUserService
    {
        private readonly IUsersRepository _usersRepository;

        private readonly IUserMapper _userMapper;

 
        public UserService(IUsersRepository usersRepository,IUserMapper userMapper)
        {
            _userMapper = userMapper;
            _usersRepository = usersRepository;
            
        }
        public List<UserDto> GetAllUsers()
        {

            List<UserDto> users = new List<UserDto>();  
            foreach (var item in _usersRepository.GetUsersFromDataBase())
            {
                UserDto user = new UserDto();

                user = _userMapper.UserToUserDtoMapp(item);
                
                users.Add(user);    
               
            }

            return users;
        }

        public UserDto GetUserById(int id)
        {
           
            var user= _usersRepository.GetUserById(id);
            UserDto userDto = new UserDto();
            userDto=_userMapper.UserToUserDtoMapp(user);
            return userDto;
        }

        public void UpdateUser(UserDto userDtoUpdated)
        {
            var user = _userMapper.UserDtoToUserMap(userDtoUpdated);

            _usersRepository.UpdateUser(user);
        }

        public void AddUser(UserDto newUser)
        {
            var user = _userMapper.UserDtoToUserMap(newUser);
            _usersRepository.AddUser(user);
        }

        public  UserDto GetUserByEmail(String email)
        {
            ApplicationUser application = new ApplicationUser();
           // application.Email = _mapper.UserDtoToUserMap(email);
            var user =  _usersRepository.GetUserByEmail(email);
           // UserDto userDto = new UserDto();
            var userDto = _userMapper.UserToUserDtoMapp(user);
            return userDto;
        }


    

    }
}
