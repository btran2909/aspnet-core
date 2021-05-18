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
        }
    }
}