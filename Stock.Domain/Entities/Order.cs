using System.ComponentModel.DataAnnotations.Schema;


namespace Trade.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { set; get; }
     
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public User User { set; get; }
        public ICollection<OrderItems> OrderItems { get; set; }
        public OrderStatus Status { set; get; }
        [ForeignKey("OrderStatus")]
        public int StatusId { set; get; }
    }
}
