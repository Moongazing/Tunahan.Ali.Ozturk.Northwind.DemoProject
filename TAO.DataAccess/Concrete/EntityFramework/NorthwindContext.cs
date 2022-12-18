using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using TAO.Entities.Concrete;

namespace TAO.DataAccess.Concrete.EntityFramework
{
  public class NorthwindContext:DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server =(localdb)\MSSQLLocalDB;Database =Northwind;Trusted_Connection=true");
      
    }
   

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Shipper> Shippers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Region> Region { get; set; }
    public DbSet<Territory> Territories { get; set; }

  }
}
