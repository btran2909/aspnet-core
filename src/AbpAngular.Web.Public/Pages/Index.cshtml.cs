using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace AbpAngular.Web.Public.Pages
{
    public class IndexModel : AbpAngularPublicPageModel
    {
        public void OnGet()
        {

        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}
