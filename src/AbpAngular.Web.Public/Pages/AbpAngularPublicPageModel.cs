using AbpAngular.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpAngular.Web.Public.Pages
{
    /* Inherit your Page Model classes from this class.
     */
    public abstract class AbpAngularPublicPageModel : AbpPageModel
    {
        protected AbpAngularPublicPageModel()
        {
            LocalizationResourceType = typeof(AbpAngularResource);
        }
    }
}
