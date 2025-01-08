using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Model.Entities
{
    public class User
    {
        [Key]
        public int userId { get; set; }

        public string userName { get; set; }
        public string Email { get; set; }
        public string passwordHash { get; set; }

        // Foreign Key to Role table
        public int RoleId { get; set; }

        // Navigation property to Role (many-to-one relationship)
        public Role Role { get; set; }

        public DateTime createdAt { get; set; }

        // Navigation property to Orders (one-to-many relationship)
        public ICollection<Order> Orders { get; set; }
    }
}
