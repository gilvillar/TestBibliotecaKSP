using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.BLL;
using Test.Entities;
using TestBackend.Models;
using TestBackend.Services;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IUserService _authService;
        private readonly TokenService _tokenService; 

        public AuthController(IUserService authService, TokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _authService.GetAllUsers();

            return Ok(users);

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _authService.GetUser(model.Username,model.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var userToken = _tokenService.GenerateToken(user);
            return Ok(userToken);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = await _authService.CreateUser(model.Username, model.Password, model.Name);

            if (user == null)
            {
                return Conflict();
            }
            else if(user.Id== 0)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Register), new { id = user.Id }, user); 
        }
    }
}
