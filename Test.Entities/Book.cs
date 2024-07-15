using System.ComponentModel.DataAnnotations;

namespace Test.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title {  get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Stock {  get; set; }
        public int LendBooks { get; set; }
        public int Available {  get; set; }
    }
}
