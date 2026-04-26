namespace DesignByTjader.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public List<ProductImage> Images { get; set; } = new();
        public List<ProductVariant> Variants { get; set; } = new();
    }
}
