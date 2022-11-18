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

        [Route("CreateNewUser")]
        [HttpPost]
        public IActionResult CreateNewUser(string first, string last, string email, string username)
        {
            if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(email) ||string.IsNullOrWhiteSpace(username))
            {
                return BadRequest("Please Try Again"); 
            }

            _userRepository.CreateNewUser(first, last, email, username);

            return GetAllUsers(); 
        }

        [Route("UpdateUser/{id}")]
        [HttpPut]
        public IActionResult UpdateUser(int id, string first, string last, string email, string username)
        {
            var user = _userRepository.GetUserById(id); 
            if(user is null)
            {
                return BadRequest("User Not Found"); 
            }

            var updatedUser = _userRepository.UpdateUser(user, first, last, email, username);

            return Ok(updatedUser); 
        }


    }
}
