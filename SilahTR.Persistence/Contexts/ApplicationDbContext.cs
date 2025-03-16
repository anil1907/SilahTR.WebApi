using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SilahTR.Application.Common.Contracts;
using SilahTR.Domain.Entities;

public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
{
    public const string UserSchema = "auth";
    public const string DefaultSchema = "public";
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        modelBuilder.HasDefaultSchema(UserSchema);
    }
} 