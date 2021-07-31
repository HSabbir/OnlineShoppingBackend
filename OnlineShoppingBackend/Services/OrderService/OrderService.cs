using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingBackend.Data;
using OnlineShoppingBackend.Dtos.Order;
using OnlineShoppingBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineShoppingBackend.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        private string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        public async Task<ServiceResponse<List<GetOrderDto>>> AddOrder(AddOrderDto newOrder)
        {
            ServiceResponse<List<GetOrderDto>> serviceResponse = new ServiceResponse<List<GetOrderDto>>();
            Order2 order = _mapper.Map<Order2>(newOrder);

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            serviceResponse.Data = (_context.Orders.Select(c => _mapper.Map<GetOrderDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOrderDto>>> DeleteOrder(int id)
        {
            ServiceResponse<List<GetOrderDto>> serviceResponse = new ServiceResponse<List<GetOrderDto>>();

            try
            {
                Order2 order = await _context.Orders.FirstAsync(c => c.Id == id);

                _context.Orders.Remove(order);

                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Orders.Select(c => _mapper.Map<GetOrderDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOrderDto>>> GetAllOrder()
        {
            ServiceResponse<List<GetOrderDto>> serviceResponse = new ServiceResponse<List<GetOrderDto>>();
            List<Order2> dbCharacters = await _context.Orders.ToListAsync();
            serviceResponse.Data = (dbCharacters.Select(c => _mapper.Map<GetOrderDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOrderDto>>> GetOrderById()
        {
            ServiceResponse<List<GetOrderDto>> serviceResponse = new ServiceResponse<List<GetOrderDto>>();
            List<Order2> dbCharacters = await _context.Orders.Where(c => c.User.Id == GetUserId()).ToListAsync();
            serviceResponse.Data = (dbCharacters.Select(c => _mapper.Map<GetOrderDto>(c))).ToList();
            return serviceResponse;
        }
    }
}
