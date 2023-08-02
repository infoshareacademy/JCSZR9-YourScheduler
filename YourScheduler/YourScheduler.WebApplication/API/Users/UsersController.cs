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
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAllUsers()
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
        public async Task<ActionResult<ApplicationUser>> GetUser(int userId)
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
        public async Task<ActionResult<ApplicationUser>> GetUser(string email)
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
        public async Task<ActionResult> AddUser(ApplicationUser user)
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



