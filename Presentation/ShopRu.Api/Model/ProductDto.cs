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
        public bool IsGrocery { get; set; }
    }
}
