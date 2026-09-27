namespace DesignByTjader.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = "Ny"; // Ny, Kontaktad, Betald, Klar, Avbruten

        public List<OrderItem> OrderItems { get; set; } = new();

        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
