using ShopRu.EntityLayer.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace ShopRu.Api.Model
{
    public class ProductDto
    {
        [SwaggerParameter("Name")]
        public string Name { get; set; }
        [SwaggerParameter("Price", Required = true)]
        public decimal Price { get; set; }
        [SwaggerParameter("Groceries,GardenSupplies,Cosmetic", Required = true)]
        public RayonType RayonType { get; set; }
    }
}
