using Microsoft.EntityFrameworkCore;

namespace AbpAngular.EntityFrameworkCore
{
    public class AbpAngularMigrationsDbContextFactory :
        AbpAngularMigrationsDbContextFactoryBase<AbpAngularMigrationsDbContext>
    {
        protected override AbpAngularMigrationsDbContext CreateDbContext(
            DbContextOptions<AbpAngularMigrationsDbContext> dbContextOptions)
        {
            return new AbpAngularMigrationsDbContext(dbContextOptions);
        }
    }
}
