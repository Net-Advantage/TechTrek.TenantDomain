namespace Nabs.TechTrek.TenantDomain.TenantPersistence;

public sealed class TenantDbContext : BaseDbContext
{
    public TenantDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TenantEntity> Tenants => Set<TenantEntity>();
}
