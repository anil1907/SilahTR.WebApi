using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SilahTR.Domain.Entities;

public class BaseDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    // public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    // public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
    // public DbSet<CreditType> CreditTypes { get; set; }
    // public DbSet<CreditApplication> CreditApplications { get; set; }

    public BaseDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
} 