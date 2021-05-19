using Volo.Abp.Application.Dtos;
using System;

namespace AbpAngular.Customers
{
    public class GetcustomersInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string LicenseNo { get; set; }
        public DateTime? LicenseExpiredMin { get; set; }
        public DateTime? LicenseExpiredMax { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Telephone { get; set; }

        public GetcustomersInput()
        {

        }
    }
}