namespace Trade.Domain.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } 
        public DateTime? DeletedAt { get; set; }
        public ICollection<StockProduct> StockProduct { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
