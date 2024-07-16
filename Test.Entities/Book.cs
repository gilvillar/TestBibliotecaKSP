using System.ComponentModel.DataAnnotations;

namespace Test.Entities
{
    /// <summary>
    /// Esta clase representa a un libro.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Id autoincremental del libro
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ITitulo del libro
        /// </summary>
        public string Title {  get; set; } = string.Empty;

        /// <summary>
        /// Autor del libro
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// Representa la cantidad de libros en stock.
        /// </summary>
        public int Stock {  get; set; }

        /// <summary>
        /// Representa la cantidad de libros prestados
        /// </summary>
        public int LendBooks { get; set; }

        /// <summary>
        /// Representa la cantidad de libros disponibles
        /// </summary>
        public int Available {  get; set; }
    }
}
