namespace Nabs.TechTrek.TenantDomain.TenantScenarios.ListTenants;

public sealed class ListTenantActivityState : IActivityState
{
    public List<Tenant> Tenants { get; set; } = [];
}


public sealed class ListTenantsActivity : Activity<ListTenantActivityState>
{
    public ListTenantsActivity(
        ListTenantActivityState activityState) 
        : base(activityState)
    {
        AddBehaviour(new ListTenantsActivityBehaviour());
    }
}

public sealed class ListTenantsActivityBehaviour 
    : IActivityStateBehaviourSync<ListTenantActivityState>
{
    public ListTenantActivityState Run(ListTenantActivityState activityState)
    {
        throw new NotImplementedException();
    }
}