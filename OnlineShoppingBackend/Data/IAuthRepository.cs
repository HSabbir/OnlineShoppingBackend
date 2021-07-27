using OnlineShoppingBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingBackend.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password, string name);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
