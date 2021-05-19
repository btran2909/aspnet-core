using AbpAngular.Customers;
using Volo.Abp.AutoMapper;
using AbpAngular.Customers;
using Volo.Abp.AutoMapper;
using System;
using AbpAngular.Shared;
using AbpAngular.Companies;
using Volo.Abp.AutoMapper;
using AutoMapper;
using AbpAngular.Users;
using Volo.Abp.AutoMapper;

namespace AbpAngular
{
    public class AbpAngularApplicationAutoMapperProfile : Profile
    {
        public AbpAngularApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<AppUser, AppUserDto>().Ignore(x => x.ExtraProperties);

            CreateMap<companyCreateDto, company>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<companyUpdateDto, company>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<company, companyDto>();

            CreateMap<customerCreateDto, customer>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<customerUpdateDto, customer>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<customer, customerDto>();

            CreateMap<customerCreateDto, customer>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<customerUpdateDto, customer>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<customer, customerDto>();
        }
    }
}