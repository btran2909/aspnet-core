using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace AbpAngular.Customers
{
    public class customer : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string LicenseNo { get; set; }

        public virtual DateTime LicenseExpired { get; set; }

        [CanBeNull]
        public virtual string Address { get; set; }

        [CanBeNull]
        public virtual string City { get; set; }

        [CanBeNull]
        public virtual string ZipCode { get; set; }

        [CanBeNull]
        public virtual string Country { get; set; }

        [CanBeNull]
        public virtual string Email { get; set; }

        [CanBeNull]
        public virtual string Website { get; set; }

        [CanBeNull]
        public virtual string Telephone { get; set; }

        public customer()
        {

        }

        public customer(Guid id, string licenseNo, DateTime licenseExpired, string address, string city, string zipCode, string country, string email, string website, string telephone)
        {
            Id = id;
            LicenseNo = licenseNo;
            LicenseExpired = licenseExpired;
            Address = address;
            City = city;
            ZipCode = zipCode;
            Country = country;
            Email = email;
            Website = website;
            Telephone = telephone;
        }
    }
}