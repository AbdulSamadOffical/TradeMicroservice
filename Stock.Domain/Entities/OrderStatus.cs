using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.Domain.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Order Order { get; set; }
    
    }
}
