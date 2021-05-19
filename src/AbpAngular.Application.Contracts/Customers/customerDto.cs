using System;
using Volo.Abp.Application.Dtos;

namespace AbpAngular.Customers
{
    public class customerDto : FullAuditedEntityDto<Guid>
    {
        public string LicenseNo { get; set; }
        public DateTime LicenseExpired { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Telephone { get; set; }
    }
}