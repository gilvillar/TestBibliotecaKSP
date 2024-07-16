using Microsoft.EntityFrameworkCore;
using Test.Entities;


namespace Test.DAL  
{
    /// <summary>
    /// Esta realiza la representacion de la base de datos
    /// </summary>
    public class ApiContext : DbContext
    {
        public ApiContext()
        {
        }   


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("LibraryDb");
        }

        //Entidad libros
        public DbSet<Book> Books { get; set; }

        //Entidad usuarios
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //se configura una clave primaria a la entidad book
            modelBuilder.Entity<Book>().
                HasKey(x => x.Id);

            //se configura una clave primaria a la entidad user
            modelBuilder.Entity<User>().
                HasKey(x => x.Id);
        }
    }
}
