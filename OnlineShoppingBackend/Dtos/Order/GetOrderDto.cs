using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShoppingBackend.Models;

namespace OnlineShoppingBackend.Dtos.Order
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
        public string PymentMethod { get; set; } = "";
        public string AccountNumber { get; set; } = "";
        public double TotalPrice { get; set; } = 0.0;
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
    }
}
