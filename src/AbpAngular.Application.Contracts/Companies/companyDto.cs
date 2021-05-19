using System;
using Volo.Abp.Application.Dtos;

namespace AbpAngular.Companies
{
    public class companyDto : FullAuditedEntityDto<Guid>
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
    }
}