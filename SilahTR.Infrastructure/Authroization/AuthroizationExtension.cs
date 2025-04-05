using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace SilahTR.Infrastructure.Authroization;

public static class AuthroizationExtension
{
    public static IServiceCollection AddAuthorizations(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            options.AddPolicy("User", policy => policy.RequireRole("User"));
        });
        
        return services;
    }
}