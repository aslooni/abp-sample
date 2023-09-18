using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Baharan.Web.Pages.Components.GoogleReCaptcha
{
    public class GoogleReCaptchaViewComponent: AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
