using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; } = false;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
