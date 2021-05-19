using Volo.Abp.Application.Dtos;
using System;

namespace AbpAngular.Companies
{
    public class GetcompaniesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string CompanyName { get; set; }
        public string Description { get; set; }

        public GetcompaniesInput()
        {

        }
    }
}