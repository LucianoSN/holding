using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Division.Queries;
using Holding.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Holding.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services
            .AddTransient<ICompanyRepository, CompanyRepository>()
            .AddTransient<IGroupRepository, GroupRepository>();

        return services;
    }
}
