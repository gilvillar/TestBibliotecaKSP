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
    /// <summary>
    /// Esta clase representa la logica de negocio de la autenticacion de usuarios.
    /// este es un comentario de prueba para el ejercicio de git
    /// </summary>
    public class AuthService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<IUserRepository> _logger;

        public AuthService(IUserRepository userRepository, ILogger<IUserRepository> Logger)
        {
            _userRepository = userRepository;
            _logger = Logger;
        }

        /// <summary>
        /// Crea un usuario.
        /// </summary>
        /// <param name="userName">El alias de usuario.</param>
        /// <param name="password">La contraseña de usuario.</param>
        /// <param name="name">El nombre real del usuario.</param>
        /// <returns>El usuario creado.</returns>
        public async Task<User?> CreateUser(string userName, string password, string name)
        {
            User user = new User();
            try
            {
                //validamos si los parametros traen datos o no
                if (string.IsNullOrEmpty(userName) &&
                    string.IsNullOrEmpty(password) &&
                    string.IsNullOrEmpty(name))
                {
                    //generamos una excepción para registrarla en log
                    throw new Exception("Todos los campos son obligartorios");
                }
                else
                {
                    user.Username = userName;
                    user.Password = password;
                    user.Name = name;

                    //verificamos si el usuario existe o no
                    var userExist = await GetUserByUserName(userName);

                    //si el usuario existe generamos una excepcion
                    if (userExist != null)
                    {
                        //generamos una excepción para registrarla en log
                        throw new Exception("El usuario ya existe");
                    }

                    //si las validaciones pasan generamos un nuevo usuario
                    return await _userRepository.CreateUser(user);
                }
                
            }
            catch (Exception ex)
            {
                //ponemos en null la variable user y generamos una excepción para registrarla en log
                user = null;
                _logger.LogError(ex, "Ocurrio un error al intentar crear el usuario.");
            }

            return user;
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario y contraseña, para el proceso de login.
        /// </summary>
        /// <param name="userName">El alias de usuario.</param>
        /// <param name="password">La contraseña de usuario.</param>
        /// <returns>El usuario consultado.</returns>
        public async Task<User?> GetUser(string userName, string password)
        {
            //creamos un usuario nuevo
            User user = new User();

            try
            {
                //asignamos los valores a los campos del usuario
                user.Username = userName;
                user.Password = password;

                //realizamos la consulta del usuario
                return await _userRepository.GetUser(user);
            }
            catch (Exception ex)
            {
                //si ocurre un error se registra en el log
                _logger.LogError(ex, "Ocurrio un error al intentar obtener al usuario");
            }

            return user;
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="userName">El alias de usuario.</param>
        /// <returns>El usuario consultado.</returns>
        public async Task<User?> GetUserByUserName(string userName)
        {
            //generamos un nuevo usuario
            User? user = new User();

            try
            {
                //realizamos la busqueda del usuario
                return await _userRepository.GetUserByUserName(userName);
            }
            catch (Exception ex)
            {
                //si ocurre un error lo mandamos al log
                _logger.LogError(ex, "Ocurrio un error al intentar obtener al usuario");
            }

            return user;
        }

        /// <summary>
        /// Obtiene una lista de todos los usuarios.
        /// </summary>
        /// <returns>Una lista de usuarios.</returns>
        public async Task<List<User>> GetAllUsers()
        {
            //devuelve la lista de usuarios
            return await _userRepository.GetAll();
        }
    }
}
