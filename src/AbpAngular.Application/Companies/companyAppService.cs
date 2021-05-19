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
using AbpAngular.Companies;

namespace AbpAngular.Companies
{
    [RemoteService(IsEnabled = false)]
    [Authorize(AbpAngularPermissions.companies.Default)]
    public class companiesAppService : ApplicationService, IcompaniesAppService
    {
        private readonly IcompanyRepository _companyRepository;

        public companiesAppService(IcompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public virtual async Task<PagedResultDto<companyDto>> GetListAsync(GetcompaniesInput input)
        {
            var totalCount = await _companyRepository.GetCountAsync(input.FilterText, input.CompanyName, input.Description);
            var items = await _companyRepository.GetListAsync(input.FilterText, input.CompanyName, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<companyDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<company>, List<companyDto>>(items)
            };
        }

        public virtual async Task<companyDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<company, companyDto>(await _companyRepository.GetAsync(id));
        }

        [Authorize(AbpAngularPermissions.companies.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyRepository.DeleteAsync(id);
        }

        [Authorize(AbpAngularPermissions.companies.Create)]
        public virtual async Task<companyDto> CreateAsync(companyCreateDto input)
        {

            var company = ObjectMapper.Map<companyCreateDto, company>(input);

            company = await _companyRepository.InsertAsync(company, autoSave: true);
            return ObjectMapper.Map<company, companyDto>(company);
        }

        [Authorize(AbpAngularPermissions.companies.Edit)]
        public virtual async Task<companyDto> UpdateAsync(Guid id, companyUpdateDto input)
        {

            var company = await _companyRepository.GetAsync(id);
            ObjectMapper.Map(input, company);
            company = await _companyRepository.UpdateAsync(company);
            return ObjectMapper.Map<company, companyDto>(company);
        }
    }
}