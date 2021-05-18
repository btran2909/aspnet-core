using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpAngular.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace AbpAngular.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpAngularDbSchemaMigrator
        : IAbpAngularDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpAngularDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the DbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope (connection string is dynamically resolved).
             */

            var dbContextType = _serviceProvider.GetRequiredService<ICurrentTenant>().IsAvailable
                ? typeof(AbpAngularTenantMigrationsDbContext)
                : typeof(AbpAngularMigrationsDbContext);

            await ((DbContext) _serviceProvider.GetRequiredService(dbContextType))
                .Database
                .MigrateAsync();
        }
    }
}
