using Microsoft.EntityFrameworkCore;
using Test.Entities;


namespace Test.DAL  
{
    public class ApiContext : DbContext
    {
        public ApiContext()
        {
        }   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("LibraryDb");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().
                HasKey(x => x.Id);

            modelBuilder.Entity<User>().
                HasKey(x => x.Id);
        }
    }
}
