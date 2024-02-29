using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.Domain.Dtos
{
    public class StockDto
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }  
        public int Id { get; set; }

    }

}
