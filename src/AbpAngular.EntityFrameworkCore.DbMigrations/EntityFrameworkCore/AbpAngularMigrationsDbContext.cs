using Microsoft.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;

namespace AbpAngular.EntityFrameworkCore
{
    public class AbpAngularMigrationsDbContext : AbpAngularMigrationsDbContextBase<AbpAngularMigrationsDbContext>
    {
        public AbpAngularMigrationsDbContext(DbContextOptions<AbpAngularMigrationsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SetMultiTenancySide(MultiTenancySides.Both);

            base.OnModelCreating(builder);
        }
    }
}
