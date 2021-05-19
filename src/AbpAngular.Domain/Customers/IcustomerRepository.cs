using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpAngular.Customers
{
    public interface IcustomerRepository : IRepository<customer, Guid>
    {
        Task<List<customer>> GetListAsync(
            string filterText = null,
            string licenseNo = null,
            DateTime? licenseExpiredMin = null,
            DateTime? licenseExpiredMax = null,
            string address = null,
            string city = null,
            string zipCode = null,
            string country = null,
            string email = null,
            string website = null,
            string telephone = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string licenseNo = null,
            DateTime? licenseExpiredMin = null,
            DateTime? licenseExpiredMax = null,
            string address = null,
            string city = null,
            string zipCode = null,
            string country = null,
            string email = null,
            string website = null,
            string telephone = null,
            CancellationToken cancellationToken = default);
    }
}