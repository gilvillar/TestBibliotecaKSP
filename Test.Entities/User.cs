using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities
{
    /// <summary>
    /// Esta clase representa a un usuario.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id autoincremental del usuario
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nombre de usuario del usuario.
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
