using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities
{
    public interface IUserService
    {
        Task<User?> CreateUser(string userName, string password, string name);
        Task<User?> GetUser(string userName, string password);


    }
}
