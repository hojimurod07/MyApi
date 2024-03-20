namespace Aplication.DTOs.ProductDTOS
{
    public class AddProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }

        public int CategoryId { get; set; }


    }
}
