using AbpAngular.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpAngular.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpAngularEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAngularApplicationContractsModule)
    )]
    public class AbpAngularDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}