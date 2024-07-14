using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Test.Entities;

namespace Test.BLL
{
    public class AuthService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<IBookRepository> _logger;

        public AuthService(IUserRepository userRepository, ILogger<IBookRepository> Logger)
        {
            _userRepository = userRepository;
            _logger = Logger;
        }

        public async Task<User?> CreateUser(string userName, string password, string name)
        {
            User user = new User();
            try
            {
                user.Username = userName;
                user.Password = password;
                user.Name = name;

                return await _userRepository.CreateUser(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error al intentar crear el usuario.");
            }

            return user;

        }

        public async Task<User?> GetUser(string userName, string password)
        {
            User user = new User();

            try
            {
                user.Username = userName;
                user.Password = password;

                return await _userRepository.GetUser(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error al intentar obtener al usuario");
            }

            return user;
        }
    }
}
