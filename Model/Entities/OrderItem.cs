using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class OrderItem
    {
        [Key]
        public int orderItemId { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; } // Quantity * Price

        // Navigation properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
