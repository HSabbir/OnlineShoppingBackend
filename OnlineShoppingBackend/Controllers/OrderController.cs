using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingBackend.Dtos.Order;
using OnlineShoppingBackend.Models;
using OnlineShoppingBackend.Services.OrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShoppingBackend.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            //int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _orderService.GetAllOrder());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle()
        {
            return Ok(await _orderService.GetOrderById());
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddOrderDto newOrder)
        {
            return Ok(await _orderService.AddOrder(newOrder));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetOrderDto>> response = await _orderService.DeleteOrder(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
