using Holding.Company.Domain;
using Holding.Data;
using Holding.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Holding.Tests;

public static class DependencyInjection
{
    private static IServiceProvider Provider()
    {
        var services = new ServiceCollection();
        
        services.AddDbContext<DataContext>(options =>
            options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

        services.AddRepository();
        services.AddDomainCompany();

        return services.BuildServiceProvider();
    }

    public static T Get<T>()
    {
        return Provider().GetRequiredService<T>();
    }
}