using Microsoft.EntityFrameworkCore;

namespace AbpAngular.EntityFrameworkCore
{
    public class AbpAngularTenantMigrationsDbContextFactory :
        AbpAngularMigrationsDbContextFactoryBase<AbpAngularTenantMigrationsDbContext>
    {
        protected override AbpAngularTenantMigrationsDbContext CreateDbContext(
            DbContextOptions<AbpAngularTenantMigrationsDbContext> dbContextOptions)
        {
            return new AbpAngularTenantMigrationsDbContext(dbContextOptions);
        }
    }
}
