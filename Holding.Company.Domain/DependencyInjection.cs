using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Holding.Company.Domain;

public static class DependencyInjection
{
   public static IServiceCollection AddDomainCompany(this IServiceCollection services)
   {
       services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
       services.AddScoped<IMediator, Mediator>();
       
       return services;
   }
}