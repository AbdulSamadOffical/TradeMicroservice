using System.ComponentModel.DataAnnotations.Schema;

namespace Trade.Domain.Entities
{
    public class OrderItems
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { set; get; }
        public Order Order { set; get; }
    
        [ForeignKey("StockProduct")]
        public int StockId { set; get; }
        public StockProduct Stock { set; get; }
        
    }
}
