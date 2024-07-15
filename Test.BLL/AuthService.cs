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
        private readonly ILogger<IUserRepository> _logger;

        public AuthService(IUserRepository userRepository, ILogger<IUserRepository> Logger)
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

                var userExist = await GetUserByUserName(userName);

                if (userExist != null)
                {
                    throw new Exception("El usuario ya existe");
                }

                return await _userRepository.CreateUser(user);
            }
            catch (Exception ex)
            {
                user = null;
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

        public async Task<User?> GetUserByUserName(string userName)
        {
            User? user = new User();

            try
            {
                return await _userRepository.GetUserByUserName(userName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error al intentar obtener al usuario");
            }

            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }
    }
}
