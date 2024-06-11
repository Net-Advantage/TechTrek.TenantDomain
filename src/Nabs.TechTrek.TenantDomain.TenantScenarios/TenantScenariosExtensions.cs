using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabs.TechTrek.TenantDomain.TenantScenarios;

public static class TenantScenariosExtensions
{
    public static IServiceCollection AddTenantScenarios(this IServiceCollection services)
    {
        services.AddScoped<IGrainRepository<TenantGrainState>, TenantGrainRepository>();
        return services;
    }
}
