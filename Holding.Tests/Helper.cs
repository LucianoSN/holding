using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Division.Queries;
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
            .AddTransient<ICompanyRepository, CompanyRepository>()
            .AddTransient<IGroupRepository, GroupRepository>();

        return services.BuildServiceProvider();
    }

    public static T GetRequiredService<T>()
    {
        var provider = Provider();
        return provider.GetRequiredService<T>();
    }
}