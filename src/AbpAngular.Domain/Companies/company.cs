using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace AbpAngular.Companies
{
    public class company : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string CompanyName { get; set; }

        [CanBeNull]
        public virtual string Description { get; set; }

        public company()
        {

        }

        public company(Guid id, string companyName, string description)
        {
            Id = id;
            Check.NotNull(companyName, nameof(companyName));
            CompanyName = companyName;
            Description = description;
        }
    }
}