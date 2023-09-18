using Baharan.Localization;
using Microsoft.Extensions.Logging;
using System;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Baharan.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class BaharanPageModel : AbpPageModel
{
    protected BaharanPageModel()
    {
        LocalizationResourceType = typeof(BaharanResource);
    }
    protected void ShowAlert(Exception exception)
    {
        Logger.LogException(exception);
        var errorInfoConverter = LazyServiceProvider.LazyGetRequiredService<IExceptionToErrorInfoConverter>();
        var errorInfo = errorInfoConverter.Convert(exception, options =>
        {
            options.SendExceptionsDetailsToClients = false;
            options.SendStackTraceToClients = false;
        });
        Alerts.Danger(errorInfo.Message);
    }
}
