namespace Nabs.TechTrek.TenantDomain.TenantPersistence;

public sealed class TenantDbContext(
    DbContextOptions<TenantDbContext> options) 
    : BaseDbContext(options)
{
    public DbSet<TenantEntity> Tenants => Set<TenantEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Must call the base
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenantDbContext).Assembly);
    }
}
