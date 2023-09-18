using System;
using System.Collections.Generic;
using System.Text;
using Baharan.Localization;
using Volo.Abp.Application.Services;

namespace Baharan;

/* Inherit your application services from this class.
 */
public abstract class BaharanAppService : ApplicationService
{
    protected BaharanAppService()
    {
        LocalizationResource = typeof(BaharanResource);
    }
}
