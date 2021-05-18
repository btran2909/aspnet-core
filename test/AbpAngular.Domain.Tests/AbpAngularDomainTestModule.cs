using AbpAngular.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpAngular
{
    [DependsOn(
        typeof(AbpAngularEntityFrameworkCoreTestModule)
        )]
    public class AbpAngularDomainTestModule : AbpModule
    {

    }
}