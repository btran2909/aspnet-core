using System;
using System.ComponentModel.DataAnnotations;

namespace AbpAngular.Companies
{
    public class companyCreateDto
    {
        [Required]
        public string CompanyName { get; set; }
        public string Description { get; set; }
    }
}