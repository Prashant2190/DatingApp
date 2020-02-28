using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.DTO;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserToRegisterDto userToRegisterDto)
        {
            userToRegisterDto.Username = userToRegisterDto.Username.ToLower();

            if(await _repo.UserExists(userToRegisterDto.Username))
            return BadRequest("User Alread Exists");

            var UserToCreate = new User
            {
                Username = userToRegisterDto.Username
            };

            var CreatedUser = await _repo.Register(UserToCreate, userToRegisterDto.Password);

            return StatusCode(201);
        }

        
    }
}