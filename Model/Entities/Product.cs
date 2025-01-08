using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        public string productName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public DateTime createdAt { get; set; }

        // Navigation property
        public ICollection<OrderItem> orderItems { get; set; }
    }
}
