using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities
{
    /// <summary>
    /// Esta interfaz representa las operaciones que se pueden realizar a un usuario.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Crea un usuario.
        /// </summary>
        /// <param name="userName">El alias de usuario.</param>
        /// <param name="password">La contraseña de usuario.</param>
        /// <param name="name">El nombre real del usuario.</param>
        /// <returns>El usuario creado.</returns>
        Task<User?> CreateUser(string userName, string password, string name);

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario y contraseña.
        /// </summary>
        /// <param name="userName">El alias de usuario.</param>
        /// <param name="password">La contraseña de usuario.</param>
        /// <returns>El usuario consultado.</returns>
        Task<User?> GetUser(string userName, string password);

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="userName">El alias de usuario.</param>
        /// <returns>El usuario consultado.</returns>
        Task<User?> GetUserByUserName(string userName);

        /// <summary>
        /// Obtiene una lista de todos los usuarios.
        /// </summary>
        /// <returns>Una lista de usuarios.</returns>
        Task<List<User>> GetAllUsers();


    }
}
