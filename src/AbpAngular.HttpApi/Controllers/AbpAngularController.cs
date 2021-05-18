using AbpAngular.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpAngular.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpAngularController : AbpController
    {
        protected AbpAngularController()
        {
            LocalizationResource = typeof(AbpAngularResource);
        }
    }
}