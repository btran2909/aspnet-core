using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using AbpAngular.Companies;

namespace AbpAngular.Controllers.Companies
{
    [RemoteService]
    [Area("app")]
    [ControllerName("company")]
    [Route("api/app/companies")]

    public class companyController : AbpController, IcompaniesAppService
    {
        private readonly IcompaniesAppService _companiesAppService;

        public companyController(IcompaniesAppService companiesAppService)
        {
            _companiesAppService = companiesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<companyDto>> GetListAsync(GetcompaniesInput input)
        {
            return _companiesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<companyDto> GetAsync(Guid id)
        {
            return _companiesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<companyDto> CreateAsync(companyCreateDto input)
        {
            return _companiesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<companyDto> UpdateAsync(Guid id, companyUpdateDto input)
        {
            return _companiesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companiesAppService.DeleteAsync(id);
        }
    }
}