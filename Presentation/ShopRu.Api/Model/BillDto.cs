namespace ShopRu.Api.Model
{
    public class BillDto
    {
        public UserDto User { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
