using EMA_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMA_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] SignUpModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(DbRepository.Users.Exists(u => u.Email == model.Email))
            {
                return BadRequest("Email already used before");
            }

            model.Id = DbRepository.Users.Count + 1;


            DbRepository.Users.Add(model);
            return CreatedAtAction("GetUser", new { id = model.Id }, model);
        }


        [HttpGet("GetUser/{id}")]
        public IActionResult GetUser(int id) 
        {
            SignUpModel? user = DbRepository.Users.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpGet("GetUsers")]
        public IActionResult GetUeser()
        {
            return Ok(DbRepository.Users);
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Email and Password are required.");
            }

            // Search for a matching user in memory
            var user = DbRepository.Users.FirstOrDefault(u =>
                u.Email.Equals(model.Email) &&
                u.Password == model.Password
            );

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            DbRepository.CurrentUser = user;
            return Ok($"Welcome back, {user.Name}!");
        }
    }
}
