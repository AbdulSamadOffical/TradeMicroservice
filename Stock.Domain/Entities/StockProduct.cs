using System.ComponentModel.DataAnnotations.Schema;

namespace Trade.Domain.Entities
{
    public class StockProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { set; get; }
        public string Symbol { set; get; } = string.Empty;
        public string CompanyName { set; get; } = string.Empty;
        public decimal Price { set; get; }
        [ForeignKey("User")]
        public string UserId { set; get; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public User User { set; get; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
