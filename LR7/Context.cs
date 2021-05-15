using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace LR7
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public Context():base("DbConnection")
        {
            
        }
    }
}
