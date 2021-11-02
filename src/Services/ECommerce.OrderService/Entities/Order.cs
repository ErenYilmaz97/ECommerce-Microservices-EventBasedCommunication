using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.OrderService.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; }
        public int Status { get; set; } //1-Waiting 2-Success 3-Failed

        public List<OrderItem> OrderItems { get; set; }

    }
}
