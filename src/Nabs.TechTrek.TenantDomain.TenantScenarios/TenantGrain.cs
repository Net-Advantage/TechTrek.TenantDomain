namespace Nabs.TechTrek.TenantDomain.TenantScenarios;

public sealed class TenantGrain(
    [PersistentState(stateName: "TenantGrainState", storageName: "tenant-storage")]
    IPersistentState<TenantGrainState> state,
    IGrainRepository<TenantGrainState> grainQueryStrategy)
        : ScenarioGrain<TenantGrainState>(state, grainQueryStrategy), ITenantGrain
{
    public Task<Result<Tenant>> Get()
    {
        var result = Result<Tenant>.Success(GrainState.State.Tenant);

        return Task.FromResult(result);
    }

    public async Task<Result> Update(Tenant tenant)
    {
        GrainState.State = GrainState.State with
        {
            Tenant = tenant
        };

        await GrainState.WriteStateAsync();

        return Result.Success();
    }
}

[GenerateSerializer, Immutable]
public sealed record TenantGrainState(
    Tenant Tenant);