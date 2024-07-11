using System.ComponentModel.DataAnnotations;

namespace Test.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title {  get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public bool IsFree {  get; set; } = true;
    }
}
