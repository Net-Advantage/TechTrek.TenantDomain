namespace Nabs.TechTrek.TenantDomain.TenantPersistence.Entities;

public sealed class TenantEntity : EntityBase<Guid>, ITenantEntity
{
    public string Name { get; set; } = default!;
    public TenantIsolationStrategy IsolationStrategy { get; set; }
}

internal sealed class TenantEntityConfiguration : IEntityTypeConfiguration<TenantEntity>
{
    public void Configure(EntityTypeBuilder<TenantEntity> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever();
    }
}