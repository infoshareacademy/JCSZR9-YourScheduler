using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.API.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usersRespistory;
        public UserController(IUsersRepository usersRepository)
        {
            _usersRespistory = usersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAllUsersAPI()
        {
            try
            {
                return Ok(_usersRespistory.GetUsersFromDataBase());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApplicationUser>> GetUserAPI(int userId)
        {
            try
            {
                var retrievedUser = _usersRespistory.GetUserById(userId);

                if (retrievedUser is null)
                {
                    return NotFound();
                }

                return Ok(retrievedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
        [HttpGet("email:string")]
        public async Task<ActionResult<ApplicationUser>> GetUserAPI(string email)
        {
            try
            {
                var retrievedUser = _usersRespistory.GetUserByEmail(email);

                if (retrievedUser is null)
                {
                    return NotFound();
                }

                return Ok(retrievedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddUserAPI(ApplicationUser user)
        {
            try
            {
                _usersRespistory.AddUser(user);
                var createdUser = _usersRespistory.GetUserByEmail(user.Email);

                string uri = Url.Action("GetUserById", new { id = createdUser.Id });
                return Created(uri, user);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error adding data to the database");
            }
        }
    }
}



