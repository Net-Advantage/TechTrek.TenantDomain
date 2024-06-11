using Ardalis.Result;
using Nabs.TechTrek.TenantDomain.TenantProjections;

namespace Nabs.TechTrek.TenantDomain.TenantContracts;

public interface ITenantGrain : IGrainWithGuidKey
{
    Task<Result<Tenant>> Get();
    Task<Result> Update(Tenant tenant);
}
