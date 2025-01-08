using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }   
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Payment>  payments { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }


    }
}
