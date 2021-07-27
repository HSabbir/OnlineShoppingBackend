using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingBackend.Dtos.Product
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = "Mobile";
        public double Price { get; set; } = 0.0;
        public int QuantityAvaiable { get; set; } = 0;
        public string Image { get; set; } = null;
    }
}
