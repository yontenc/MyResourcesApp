using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyResourcesApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyResourcesApp.Models
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Customer> customer { get; set; }

        public DbSet<Site> site { get; set; }

        public DbSet<Product> product { get; set; }

        public DbSet<DepositAdance> advance { get; set; }
        public DbSet<DepositAdvanceHistory> advancehistory { get; set; }

        public DbSet<PlaceOrder> order { get; set; }
        public DbSet<UserInfo> user { get; set; }
    }
}
