using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AbpAngular.EntityFrameworkCore
{
    public static class AbpAngularDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpAngular(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpAngularConsts.DbTablePrefix + "YourEntities", AbpAngularConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            //if (builder.IsHostDatabase())
            //{
            //    /* Tip: Configure mappings like that for the entities only available in the host side,
            //     * but should not be in the tenant databases. */
            //}
        }
    }
}