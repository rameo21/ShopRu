using ShopRu.EntityLayer.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace ShopRu.Api.Model
{
    public class UserDto
    {
        [SwaggerParameter("Employee,Affiliate, Customer", Required = true)]
        public UserType UserType { get; set; } // "Employee", "Affiliate", "Customer"
        [SwaggerParameter("joined date", Required = true)]
        public DateTime InsertDate { get; set; } // Date when the user joined the store
    }
}
