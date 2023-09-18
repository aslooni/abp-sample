using Account.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Account;

public abstract class AccountController : AbpControllerBase
{
    protected AccountController()
    {
        LocalizationResource = typeof(AccountResource);
    }
}
