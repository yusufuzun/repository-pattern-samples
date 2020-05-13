using RepositoryLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DAL.EF
{
    public class ModelContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
