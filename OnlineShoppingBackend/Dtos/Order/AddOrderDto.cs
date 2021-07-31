using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingBackend.Dtos.Order
{
    public class AddOrderDto
    {
        public string Address { get; set; } = "";
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string PymentMethod { get; set; } = "";
        public string AccountNumber { get; set; } = "";
        public double TotalPrice { get; set; } = 0.0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
    }
}
