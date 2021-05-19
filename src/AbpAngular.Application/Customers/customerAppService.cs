using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using AbpAngular.Permissions;
using AbpAngular.Customers;

namespace AbpAngular.Customers
{
    [RemoteService(IsEnabled = false)]
    [Authorize(AbpAngularPermissions.customers.Default)]
    public class customersAppService : ApplicationService, IcustomersAppService
    {
        private readonly IcustomerRepository _customerRepository;

        public customersAppService(IcustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public virtual async Task<PagedResultDto<customerDto>> GetListAsync(GetcustomersInput input)
        {
            var totalCount = await _customerRepository.GetCountAsync(input.FilterText, input.LicenseNo, input.LicenseExpiredMin, input.LicenseExpiredMax, input.Address, input.City, input.ZipCode, input.Country, input.Email, input.Website, input.Telephone);
            var items = await _customerRepository.GetListAsync(input.FilterText, input.LicenseNo, input.LicenseExpiredMin, input.LicenseExpiredMax, input.Address, input.City, input.ZipCode, input.Country, input.Email, input.Website, input.Telephone, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<customerDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<customer>, List<customerDto>>(items)
            };
        }

        public virtual async Task<customerDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<customer, customerDto>(await _customerRepository.GetAsync(id));
        }

        [Authorize(AbpAngularPermissions.customers.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        [Authorize(AbpAngularPermissions.customers.Create)]
        public virtual async Task<customerDto> CreateAsync(customerCreateDto input)
        {

            var customer = ObjectMapper.Map<customerCreateDto, customer>(input);

            customer = await _customerRepository.InsertAsync(customer, autoSave: true);
            return ObjectMapper.Map<customer, customerDto>(customer);
        }

        [Authorize(AbpAngularPermissions.customers.Edit)]
        public virtual async Task<customerDto> UpdateAsync(Guid id, customerUpdateDto input)
        {

            var customer = await _customerRepository.GetAsync(id);
            ObjectMapper.Map(input, customer);
            customer = await _customerRepository.UpdateAsync(customer);
            return ObjectMapper.Map<customer, customerDto>(customer);
        }
    }
}