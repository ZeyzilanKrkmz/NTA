using System.Diagnostics;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NTA.Core.Models;

namespace NTA.Core.Repositories;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
    }
    
}