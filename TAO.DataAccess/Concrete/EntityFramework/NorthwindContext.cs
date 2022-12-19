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
  public class NorthwindContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server =(localdb)\MSSQLLocalDB;Database =Northwind;Trusted_Connection=true");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      #region ProductMap
      modelBuilder.Entity<Product>(a =>
      {
        a.ToTable("Products").HasKey(p => p.ProductID);
        a.Property(p => p.ProductID).HasColumnName("ProductID");
        a.Property(p => p.ProductName).HasColumnName("ProductName");
        a.Property(p => p.SupplierID).HasColumnName("SupplierID");
        a.Property(p => p.CategoryID).HasColumnName("CategoryID");
        a.Property(p => p.QuantityPerUnit).HasColumnName("QuantityPerUnit");
        a.Property(p => p.UnitPrice).HasColumnName("UnitPrice");
        a.Property(p => p.UnitsInStock).HasColumnName("UnitsInStock");
        a.Property(p => p.UnitsOnOrder).HasColumnName("UnitsOnOrder");
        a.Property(p => p.ReorderLevel).HasColumnName("ReorderLevel");
        a.Property(p => p.Discontinued).HasColumnName("Discontinued");
      });
      #endregion
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
