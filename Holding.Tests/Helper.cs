using Holding.Company.Domain.Company.Queries;
using Holding.Data.Contexts;
using Holding.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Holding.Tests;

public static class Helper
{
    private static IServiceProvider Provider()
    {
        var services = new ServiceCollection();
        
        services.AddDbContext<DataContext>(options =>
            options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

        services
            .AddTransient<ICompanyRepository, CompanyRepository>();

        return services.BuildServiceProvider();
    }

    public static T GetRequiredService<T>()
    {
        var provider = Provider();
        return provider.GetRequiredService<T>();
    }
}