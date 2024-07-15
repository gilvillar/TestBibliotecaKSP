using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using Test.BLL;
using Test.DAL;
using Test.Entities;
using TestBackend.Controllers;
using TestBackend.Models;
using TestBackend.Services;

namespace TestBibliotecaUnitTesting
{
    public class AuthTest
    {
        private readonly AuthController _controller;
        private readonly IUserService _authService;
        private readonly IUserRepository _userRepository;
        private readonly TokenService tokenService;

        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<IUserRepository> _logger;

        public AuthTest()
        {
            // Configurar el ILoggerFactory
            _loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("MyTests", LogLevel.Debug)
                    .AddConsole(); // Puedes añadir otros proveedores de logging aquí (e.g., Debug, EventSource, etc.)
            });

            // Crear un logger para esta clase de pruebas
            _logger = _loggerFactory.CreateLogger<IUserRepository>();


            //_logger = new ILogger;
            tokenService = new TokenService("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiIxIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkdpbGJlcnRvIFZpbGxhIiwianRpIjoiM2YxZGE3N2ItNDRlYi00OTQ5LTkwZjMtZGVmMDBhYmFmNjg2IiwiZXhwIjoxNzIwOTg2NjY3fQ.JGOKLE5O6UqQ3Wq3z7kREIcqJyAnbIOFXhbuElFrxqk");
            _userRepository = new UserRepository();
            _authService = new AuthService(_userRepository, _logger);
            _controller = new AuthController(_authService, tokenService);
        }


        //validamos un login exitoso
        [Fact]
        public void Login_OK()
        {
            //Arrange

            LoginModel model = new LoginModel {
                Username = "admin",
                Password = "admingvr",
            };

            //Act

            var okResult = _controller.Login(model).Result as OkObjectResult;
            var userToken = okResult.Value as UserToken;

            //Assert

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotEmpty(userToken.Token);

        }

        //validamos un login fallido
        [Fact]
        public void Login_Fail()
        {
            //Arrange

            LoginModel model = new LoginModel
            {
                Username = "admin",
                Password = "admin",
            };

            //Act

            var failResult = _controller.Login(model).Result as UnauthorizedResult;

            //Assert

            Assert.NotNull(failResult);
            Assert.Equal(401, failResult.StatusCode);
        }

        //validamos un registro de usuario correcto
        [Fact]
        public void Register_Ok()
        {
            //Arrange

            RegisterModel model = new RegisterModel
            {
                Username = "prueba1",
                Password = "prueba1",
                Name="Gilberto"
            };

            //Act

            var okResult = _controller.Register(model).Result as CreatedAtActionResult;

            //Assert

            Assert.NotNull(okResult);
            Assert.Equal(201, okResult.StatusCode);
        }

        //validamos un registro de usuario fallido
        [Fact]
        public void Register_Fail()
        {
            //Arrange

            RegisterModel model = new RegisterModel
            {
                Username = "admin",
                Password = "admin",
                Name = "Gilberto"
            };

            //Act

            var okResult = _controller.Register(model).Result as ConflictResult;

            //Assert

            Assert.NotNull(okResult);
            Assert.Equal(409, okResult.StatusCode);
        }

        //validamos el listado de usuarios correcto
        [Fact]
        public void GetUsers_Ok()
        {
            //Arrange


            //Act

            var okResult = _controller.GetAllUsers().Result;

            //Assert

            Assert.IsType<ActionResult<List<User>>>(okResult);
        }
    }
}

class TestListUser
{

}