#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace ECommerce.Models;

public class ECommerceContext : DbContext 
{ 
    public ECommerceContext(DbContextOptions options) : base(options) { }

    public DbSet<Customer> Customers { get; set; } 
    public DbSet<Product> Products { get; set; } 
    public DbSet<Order> Orders { get; set; } 
}