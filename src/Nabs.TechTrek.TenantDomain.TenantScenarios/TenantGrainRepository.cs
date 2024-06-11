namespace Nabs.TechTrek.TenantDomain.TenantScenarios;

public sealed class TenantGrainRepository : IGrainRepository<TenantGrainState>
{
    private readonly IDbContextFactory<TenantDbContext> _dbContextFactory;

    public TenantGrainRepository(IDbContextFactory<TenantDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<Result<TenantGrainState>> Query(IScenarioGrain grain)
    {
        var id = grain.GetPrimaryKey();

        var dbContext = _dbContextFactory.CreateDbContext();
        var tenantEntity = await dbContext.Tenants.AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);

        if (tenantEntity == null)
        {
            throw new InvalidOperationException("Tenant not found");
        }

        var tenant = new Tenant(
            tenantEntity.Id,
            tenantEntity.Name);

        return new TenantGrainState(tenant);
    }


    public async Task<Result> Persist(IScenarioGrain grain, TenantGrainState state)
    {
        var id = grain.GetPrimaryKey();

        var dbContext = _dbContextFactory.CreateDbContext();

        var tenantEntity = await dbContext.Tenants
            .FirstOrDefaultAsync(r => r.Id == id);

        if (tenantEntity == null)
        {
            throw new InvalidOperationException("Tenant not found");
        }

        tenantEntity.Name = state.Tenant.Name;
        await dbContext.SaveChangesAsync();

        return Result.Success();
    }

    
}