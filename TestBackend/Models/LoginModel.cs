namespace TestBackend.Models
{
    /// <summary>
    /// Esta clase representa el inicio de sesión.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string UserName { get; set; } = string.Empty;
        /// <summary>
        /// Contraseña
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
