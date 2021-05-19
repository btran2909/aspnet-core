using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using AbpAngular.Customers;

namespace AbpAngular.Controllers.Customers
{
    [RemoteService]
    [Area("app")]
    [ControllerName("customer")]
    [Route("api/app/customers")]

    public class customerController : AbpController, IcustomersAppService
    {
        private readonly IcustomersAppService _customersAppService;

        public customerController(IcustomersAppService customersAppService)
        {
            _customersAppService = customersAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<customerDto>> GetListAsync(GetcustomersInput input)
        {
            return _customersAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<customerDto> GetAsync(Guid id)
        {
            return _customersAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<customerDto> CreateAsync(customerCreateDto input)
        {
            return _customersAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<customerDto> UpdateAsync(Guid id, customerUpdateDto input)
        {
            return _customersAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _customersAppService.DeleteAsync(id);
        }
    }
}