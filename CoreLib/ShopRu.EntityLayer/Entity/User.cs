using ShopRu.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.EntityLayer.Entity
{
    // User class to represent a user
    public class User
    {
        public int Id { get; set; }
        public UserType UserType { get; set; } // "Employee", "Affiliate", "Customer"
        public DateTime InsertDate { get; set; } // Date when the user joined the store
    }
}
