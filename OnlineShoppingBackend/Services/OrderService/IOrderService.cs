using OnlineShoppingBackend.Dtos.Order;
using OnlineShoppingBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingBackend.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<List<GetOrderDto>>> GetAllOrder();
        Task<ServiceResponse<List<GetOrderDto>>> GetOrderById();
        Task<ServiceResponse<List<GetOrderDto>>> AddOrder(AddOrderDto newOrder);
        Task<ServiceResponse<List<GetOrderDto>>> DeleteOrder(int id);
    }
}
