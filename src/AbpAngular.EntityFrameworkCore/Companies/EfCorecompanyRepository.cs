using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using AbpAngular.EntityFrameworkCore;

namespace AbpAngular.Companies
{
    public class EfCorecompanyRepository : EfCoreRepository<AbpAngularDbContext, company, Guid>, IcompanyRepository
    {
        public EfCorecompanyRepository(IDbContextProvider<AbpAngularDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<company>> GetListAsync(
            string filterText = null,
            string companyName = null,
            string description = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyName, description);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? companyConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string companyName = null,
            string description = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyName, description);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<company> ApplyFilter(
            IQueryable<company> query,
            string filterText,
            string companyName = null,
            string description = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CompanyName.Contains(filterText) || e.Description.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyName), e => e.CompanyName.Contains(companyName))
                    .WhereIf(!string.IsNullOrWhiteSpace(description), e => e.Description.Contains(description));
        }
    }
}