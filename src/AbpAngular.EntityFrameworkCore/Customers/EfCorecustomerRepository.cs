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

namespace AbpAngular.Customers
{
    public class EfCorecustomerRepository : EfCoreRepository<AbpAngularDbContext, customer, Guid>, IcustomerRepository
    {
        public EfCorecustomerRepository(IDbContextProvider<AbpAngularDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<customer>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, licenseNo, licenseExpiredMin, licenseExpiredMax, address, city, zipCode, country, email, website, telephone);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? customerConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, licenseNo, licenseExpiredMin, licenseExpiredMax, address, city, zipCode, country, email, website, telephone);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<customer> ApplyFilter(
            IQueryable<customer> query,
            string filterText,
            string licenseNo = null,
            DateTime? licenseExpiredMin = null,
            DateTime? licenseExpiredMax = null,
            string address = null,
            string city = null,
            string zipCode = null,
            string country = null,
            string email = null,
            string website = null,
            string telephone = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.LicenseNo.Contains(filterText) || e.Address.Contains(filterText) || e.City.Contains(filterText) || e.ZipCode.Contains(filterText) || e.Country.Contains(filterText) || e.Email.Contains(filterText) || e.Website.Contains(filterText) || e.Telephone.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(licenseNo), e => e.LicenseNo.Contains(licenseNo))
                    .WhereIf(licenseExpiredMin.HasValue, e => e.LicenseExpired >= licenseExpiredMin.Value)
                    .WhereIf(licenseExpiredMax.HasValue, e => e.LicenseExpired <= licenseExpiredMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(address), e => e.Address.Contains(address))
                    .WhereIf(!string.IsNullOrWhiteSpace(city), e => e.City.Contains(city))
                    .WhereIf(!string.IsNullOrWhiteSpace(zipCode), e => e.ZipCode.Contains(zipCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(country), e => e.Country.Contains(country))
                    .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email.Contains(email))
                    .WhereIf(!string.IsNullOrWhiteSpace(website), e => e.Website.Contains(website))
                    .WhereIf(!string.IsNullOrWhiteSpace(telephone), e => e.Telephone.Contains(telephone));
        }
    }
}