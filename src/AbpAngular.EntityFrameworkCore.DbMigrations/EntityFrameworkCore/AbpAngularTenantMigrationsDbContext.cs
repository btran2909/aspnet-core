using Microsoft.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;

namespace AbpAngular.EntityFrameworkCore
{
    public class AbpAngularTenantMigrationsDbContext : AbpAngularMigrationsDbContextBase<AbpAngularTenantMigrationsDbContext>
    {
        public AbpAngularTenantMigrationsDbContext(DbContextOptions<AbpAngularTenantMigrationsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SetMultiTenancySide(MultiTenancySides.Tenant);

            base.OnModelCreating(builder);
        }
    }
}
