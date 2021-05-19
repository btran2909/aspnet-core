using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpAngular.Companies
{
    public interface IcompaniesAppService : IApplicationService
    {
        Task<PagedResultDto<companyDto>> GetListAsync(GetcompaniesInput input);

        Task<companyDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<companyDto> CreateAsync(companyCreateDto input);

        Task<companyDto> UpdateAsync(Guid id, companyUpdateDto input);
    }
}