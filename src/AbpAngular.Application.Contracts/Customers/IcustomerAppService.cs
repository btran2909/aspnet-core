using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpAngular.Customers
{
    public interface IcustomersAppService : IApplicationService
    {
        Task<PagedResultDto<customerDto>> GetListAsync(GetcustomersInput input);

        Task<customerDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<customerDto> CreateAsync(customerCreateDto input);

        Task<customerDto> UpdateAsync(Guid id, customerUpdateDto input);
    }
}