using CarsAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            if (users.Count() == 0)
            {
                return BadRequest("No Current Users");
            }
          
            return Ok(users);
        }

        [Route("GetUser/{id}")]
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return BadRequest("User Not Found"); 
            }

            return Ok(user);
        }


    }
}
