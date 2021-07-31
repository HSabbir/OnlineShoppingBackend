using OnlineShoppingBackend.Dtos.User;
using OnlineShoppingBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingBackend.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAllUser();
        Task<ServiceResponse<GetUserDto>> GetUserById(int id);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedProduct);
        Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id);
    }
}
