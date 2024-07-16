using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entities;

namespace Test.DAL
{
    /// <summary>
    /// Esta clase realiza las operaciones a la tabla de usuarios.
    /// </summary>
    public class UserRepository:IUserRepository
    {
        public UserRepository()
        {
            //realizamos la carga de los datos iniciales
            InitializedData();
        }

        /// <summary>
        /// Crea un usuario en la bd.
        /// </summary>
        /// <param name="User">Objeto de tipo User.</param>
        /// <returns>El usuario consultado.</returns>
        public async Task<User?> CreateUser(User user)
        {
            using (var _context = new ApiContext())
            {
                _context.Add(user);
                await _context.SaveChangesAsync();

            }

            return user;
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario y contraseña.
        /// </summary>
        /// <param name="user">Objeto de tipo User.</param>
        /// <returns>El usuario consultado.</returns>
        public async Task<User?> GetUser(User? user)
        {
            using (var _context = new ApiContext())
            {
                user = await _context.Users.
                    Where(x => x.Username == user.Username && x.Password == user.Password).
                    FirstOrDefaultAsync();
            }

            return user;
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario y contraseña.
        /// </summary>
        /// <param name="userName">El nombre de usuario a buscar en la base de datos.</param>
        /// <returns>El usuario consultado.</returns>
        public async Task<User?> GetUserByUserName(string userName)
        {
            User? user = new User();

            using (var _context = new ApiContext())
            {
                user = await _context.Users.
                    Where(x => x.Username == userName).
                    FirstOrDefaultAsync();
            }

            return user;
        }

        /// <summary>
        /// Obtiene una lista de usuarios.
        /// </summary>
        /// <returns>Una lista de usuarios.</returns>
        public async Task<List<User>> GetAll()
        {
            List<User> users = new List<User>();

            using (var _context = new ApiContext())
            {
                users = await _context.Users.ToListAsync();
            }

            return users;
        }

        /// <summary>
        /// Inserta datos iniciales a la base de datos
        /// </summary>
        private void InitializedData()
        {
            using (var _context = new ApiContext())
            {
                if (!_context.Users.Any())
                {
                    var item = new User
                    {
                        Id = 1,
                        Username = "admin",
                        Password = "admingvr",
                        Name = "Gilberto Villa"
                    }; 

                    _context.Users.Add(item);
                    _context.SaveChanges();
                }
            }
        }
    }
}
