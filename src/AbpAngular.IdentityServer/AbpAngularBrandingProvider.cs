using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpAngular
{
    [Dependency(ReplaceServices = true)]
    public class AbpAngularBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpAngular";
    }
}
