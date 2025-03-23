using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SilahTR.Application.Common.Contracts;
using SilahTR.Domain.Entities;
using SilahTR.Domain.Entities.Identity;

namespace SilahTR.Persistence.Contexts;

public class ApplicationDbContext : IdentityDbContext<
    ApplicationUser, 
    IdentityRole<Guid>, 
    Guid,
    IdentityUserClaim<Guid>,
    IdentityUserRole<Guid>,
    IdentityUserLogin<Guid>,
    IdentityRoleClaim<Guid>,
    IdentityUserToken<Guid>>, IApplicationDbContext
{
    public const string UserSchema = "auth";
    public const string DefaultSchema = "public";
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        builder.HasDefaultSchema(UserSchema);
    }
} 