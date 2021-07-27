using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingBackend.Models
{
    public class Order
    {
        

        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PymentMethod { get; set; }
        public string AccountNumber { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }

    }
}
