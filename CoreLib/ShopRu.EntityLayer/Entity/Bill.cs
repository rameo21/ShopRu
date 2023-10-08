using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.EntityLayer.Entity
{
    // Sales class to represent a bill with items and a user
    public class Bill
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}
