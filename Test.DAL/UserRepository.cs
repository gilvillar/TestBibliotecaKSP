using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entities;

namespace Test.DAL
{
    public class UserRepository:IUserRepository
    {
        public UserRepository()
        {
            InitializedData();
        }

        public async Task<User?> CreateUser(User user)
        {
            using (var _context = new ApiContext())
            {
                _context.Add(user);
                await _context.SaveChangesAsync();

            }

            return user;
        }

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

        public async Task<List<User>> GetAll()
        {
            List<User> users = new List<User>();

            using (var _context = new ApiContext())
            {
                users = await _context.Users.ToListAsync();
            }

            return users;
        }

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
