using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SilahTR.Application.Common.Interfaces;
using SilahTR.Application.Features.Categories.Rules;
using SilahTR.Application.Services.Auth;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration => 
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Business Rules
        services.AddScoped<CategoryBusinessRules>();
        
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}