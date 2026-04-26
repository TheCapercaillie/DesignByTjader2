namespace DesignByTjader.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string Color { get; set; } = string.Empty;
    }
}
