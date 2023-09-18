using Baharan.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Baharan.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BaharanController : AbpControllerBase
{
    protected BaharanController()
    {
        LocalizationResource = typeof(BaharanResource);
    }
}
