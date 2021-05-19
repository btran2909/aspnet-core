using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpAngular.Companies
{
    public interface IcompanyRepository : IRepository<company, Guid>
    {
        Task<List<company>> GetListAsync(
            string filterText = null,
            string companyName = null,
            string description = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string companyName = null,
            string description = null,
            CancellationToken cancellationToken = default);
    }
}