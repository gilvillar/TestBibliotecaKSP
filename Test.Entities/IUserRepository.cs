using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities
{
    /// <summary>
    /// Esta interfaz representa las operaciones que se pueden realizar a la tabla de usuarios.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Crea un usuario en la bd.
        /// </summary>
        /// <param name="User">Objeto de tipo User.</param>
        /// <returns>El usuario consultado.</returns>
        Task<User?> CreateUser(User user);

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario y contraseña.
        /// </summary>
        /// <param name="user">Objeto de tipo User.</param>
        /// <returns>El usuario consultado.</returns>
        Task<User?> GetUser(User user);

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario y contraseña.
        /// </summary>
        /// <param name="userName">El nombre de usuario a buscar en la base de datos.</param>
        /// <returns>El usuario consultado.</returns>
        Task<User?> GetUserByUserName(string userName);

        /// <summary>
        /// Obtiene una lista de usuarios.
        /// </summary>
        /// <returns>Una lista de usuarios.</returns>
        Task<List<User>> GetAll();
    }
}
