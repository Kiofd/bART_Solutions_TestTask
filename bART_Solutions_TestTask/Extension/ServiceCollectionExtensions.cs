using bART_Solutions_TestTask.Repositories;
using bART_Solutions_TestTask.Services;

namespace bART_Solutions_TestTask.Extension;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IIncidentRepository, IncidentRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IIncidentService, IncidentService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ICustomerService, CustomerService>();
        
        return services;
    }
}