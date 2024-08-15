using Holding.Data;
using Holding.Data.Contexts;
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

        services.AddData();

        return services.BuildServiceProvider();
    }

    public static T GetRequiredService<T>()
    {
        return Provider().GetRequiredService<T>();
    }
}