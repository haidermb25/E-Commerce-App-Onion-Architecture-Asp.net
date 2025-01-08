using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // "Card", "PayPal", "COD"
        public string PaymentStatus { get; set; } // "Success", "Failed", "Pending"

        // Navigation property
        public Order Order { get; set; }
    }
}
