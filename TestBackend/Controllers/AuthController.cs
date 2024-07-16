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
    /// <summary>
    /// Esta clase representa la capa de presentacion de la autenticacion de usuarios.
    /// </summary>

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

        /// <summary>
        /// Endpoint que Crea un usuario.
        /// </summary>
        /// <param name="userName">El alias de usuario.</param>
        /// <param name="password">La contraseña de usuario.</param>
        /// <param name="name">El nombre real del usuario.</param>
        /// <returns>Conflict o BadRequest</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            //pasamos el usuario y password al servicio
            var user = await _authService.CreateUser(model.UserName, model.Password, model.Name);

            //si el valor de retorno es null generamos un ConflicResult
            //puede ser que el usuario ya exista 
            if (user == null)
            {
                return Conflict();
            }
            else if(user.Id== 0) //si el valor de la propiedad es igual a cero ocurrio un error mas interno
            {
                return BadRequest();
            }

            //si todo pasabie retornamos un CreatedAtActionResult
            return CreatedAtAction(nameof(Register), new { id = user.Id }, user); 
        }

        /// <summary>
        /// Realiza el proceso de login de un usuario por su nombre de usuario y contraseña
        /// </summary>
        /// <param name="model">El Objeto que contiene el usuario y contraseña</param>
        /// <returns>Unauthorized o OkObjectResult</returns>
        /// 
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _authService.GetUser(model.UserName,model.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var userToken = _tokenService.GenerateToken(user);
           
            return Ok(userToken);
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="userName">El alias de usuario.</param>
        /// <returns>OkObjectResult</returns>
        [HttpGet("User")]
        public async Task<ActionResult<List<User>>> GetUser(string userName)
        {
            //obtenemos el nombre de usuario
            var user = await _authService.GetUserByUserName(userName);

            return Ok(user);

        }

        /// <summary>
        /// Obtiene una lista de todos los usuarios.
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            //obtenemos la lista de usuarios
            var users = await _authService.GetAllUsers();

            return Ok(users);

        }




    }
}
