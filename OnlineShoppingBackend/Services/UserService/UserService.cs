using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingBackend.Data;
using OnlineShoppingBackend.Dtos.User;
using OnlineShoppingBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingBackend.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UserService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();

            try
            {
                User user = await _context.Users.FirstAsync(c => c.Id == id);

                _context.Users.Remove(user);

                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Users.Select(c => _mapper.Map<GetUserDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUser()
        {

            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();
            List<User> dBUsers = await _context.Users.ToListAsync();
            serviceResponse.Data = serviceResponse.Data = (dBUsers.Select(c => _mapper.Map<GetUserDto>(c))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();
            User dBUser = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetUserDto>(dBUser);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();

            try
            {
                User user = await _context.Users.FirstOrDefaultAsync(c => c.Id == updatedUser.Id);
                user.Role = updatedUser.Role;


                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
