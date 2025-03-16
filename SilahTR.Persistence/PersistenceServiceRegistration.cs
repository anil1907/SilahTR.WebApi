using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SilahTR.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using SilahTR.Application.Common.Contracts;
using SilahTR.Domain.Entities;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddDataProtection();
        
        services.AddIdentityCore<User>(options =>
            {
                options.Tokens.EmailConfirmationTokenProvider = "EmailConfirmationTokenProvider";
                options.Tokens.PasswordResetTokenProvider = "PasswordResetTokenProvider";

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(365 * 100);
                options.Lockout.MaxFailedAccessAttempts = 5; // jwtConfig.MaxFailedAccessAttemts
                options.Lockout.AllowedForNewUsers = true;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddApiEndpoints();

        
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        // Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        // services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
        // services.AddScoped<ICreditTypeRepository, CreditTypeRepository>();
        // services.AddScoped<ICreditApplicationRepository, CreditApplicationRepository>();

        return services;
    }
}