using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyResourcesApp.Models;
using Microsoft.EntityFrameworkCore;


namespace MyResourcesApp.Models
{
    public class ApplicationContext :  DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Customer> customer { get; set; }

        public DbSet<Site> siteInfo { get; set; }

        public DbSet<Product> product { get; set; }

        public DbSet<DepositAdance> advanceDeposit { get; set; }
        public DbSet<DepositAdvanceHistory> depositAdvanceHistory { get; set; }
        public DbSet<PlaceOrder> orders { get; set; }
    }
}
