using AbpAngular.Customers;
using Volo.Abp.EntityFrameworkCore.Modeling;
using AbpAngular.Companies;
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
            if (builder.IsHostDatabase())
            {
                builder.Entity<company>(b =>
    {
        b.ToTable(AbpAngularConsts.DbTablePrefix + "companies", AbpAngularConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.CompanyName).HasColumnName(nameof(company.CompanyName)).IsRequired();
        b.Property(x => x.Description).HasColumnName(nameof(company.Description));
    });

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<customer>(b =>
    {
        b.ToTable(AbpAngularConsts.DbTablePrefix + "customers", AbpAngularConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.LicenseNo).HasColumnName(nameof(customer.LicenseNo));
        b.Property(x => x.LicenseExpired).HasColumnName(nameof(customer.LicenseExpired));
        b.Property(x => x.Address).HasColumnName(nameof(customer.Address));
        b.Property(x => x.City).HasColumnName(nameof(customer.City));
        b.Property(x => x.ZipCode).HasColumnName(nameof(customer.ZipCode));
        b.Property(x => x.Country).HasColumnName(nameof(customer.Country));
        b.Property(x => x.Email).HasColumnName(nameof(customer.Email));
        b.Property(x => x.Website).HasColumnName(nameof(customer.Website));
        b.Property(x => x.Telephone).HasColumnName(nameof(customer.Telephone));
    });

            }
        }
    }
}