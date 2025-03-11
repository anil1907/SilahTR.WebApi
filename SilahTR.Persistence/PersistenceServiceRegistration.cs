using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SilahTR.Persistence.Repositories;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext
        services.AddDbContext<BaseDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        // Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        // services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
        // services.AddScoped<ICreditTypeRepository, CreditTypeRepository>();
        // services.AddScoped<ICreditApplicationRepository, CreditApplicationRepository>();

        return services;
    }
}