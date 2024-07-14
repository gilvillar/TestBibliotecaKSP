using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities
{
    public  interface IUserRepository
    {
        Task<User?> CreateUser(User user);
        Task<User?> GetUser(User user);
    }
}
