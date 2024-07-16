namespace TestBackend.Models
{
    /// <summary>
    /// Esta clase representa el registro de usuario.
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// Nombre o alias de usuario
        /// </summary>
        public string UserName { get; set; } = string.Empty;
        /// <summary>
        /// Contraseña
        /// </summary>
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// Nombre real del usuario
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
