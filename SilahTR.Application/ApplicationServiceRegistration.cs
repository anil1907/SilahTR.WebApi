using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

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
        // services.AddScoped<IndividualCustomerBusinessRules>();
        // services.AddScoped<CorporateCustomerBusinessRules>();

        return services;
    }
}