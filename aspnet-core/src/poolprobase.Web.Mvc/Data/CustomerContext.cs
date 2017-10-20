using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using poolprobase.Web.Models.Customer;

namespace poolprobase.Web.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<ServiceTech> ServiceTechs { get; set; }
        public object Customer { get; internal set; }
    }
}
