using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public int userId { get; set; }
        public DateTime orderDate { get; set; }
        public decimal totalAmount { get; set; }
        public string Status { get; set; } // "Pending", "Shipped", "Completed", "Cancelled"

        // Navigation properties
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Payment Payment { get; set; }
    }
}
