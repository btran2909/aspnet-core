using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpAngular.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpAngularEntityFrameworkCoreModule)
    )]
    public class AbpAngularEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpAngularMigrationsDbContext>();
            context.Services.AddAbpDbContext<AbpAngularTenantMigrationsDbContext>();
        }
    }
}
