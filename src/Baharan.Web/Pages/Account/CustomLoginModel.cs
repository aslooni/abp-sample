using Baharan.Permissions;
using Baharan.Web.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Account.Settings;
using Volo.Abp.Account.Web.Pages.Account;
using Volo.Abp.Identity;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Settings;

namespace Baharan.Web.Pages.Account
{
    public class CustomLoginModel : LoginModel
    {
        private readonly GoogleReCaptchaService _googleReCaptchaService;
        private readonly IPermissionManager _permissionManager;
        private readonly RoleManager<Volo.Abp.Identity.IdentityRole> _roleManager;

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        [Required]
        public string RecaptchaToken { get; set; }
        public CustomLoginModel(
            IAuthenticationSchemeProvider schemeProvider,
            IOptions<Volo.Abp.Account.Web.AbpAccountOptions> accountOptions,
            IOptions<IdentityOptions> identityOptions, GoogleReCaptchaService googleReCaptchaService,
            IPermissionManager permissionManager,
            RoleManager<Volo.Abp.Identity.IdentityRole> roleManager) : base(schemeProvider, accountOptions, identityOptions)
        {
            _googleReCaptchaService = googleReCaptchaService;
            _permissionManager = permissionManager;
            _roleManager = roleManager;
        }
        public override async Task<IActionResult> OnPostAsync(string action)
        {
            var isValidCaptcha = await _googleReCaptchaService.VerifyToken(RecaptchaToken);
            if (!ModelState.IsValid || !isValidCaptcha)
            {
                return Page();
            }
            await CheckLocalLoginAsync();

            ValidateModel();

            ExternalProviders = await GetExternalProviders();

            EnableLocalLogin = await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin);

            await ReplaceEmailToUsernameOfInputIfNeeds();

            await IdentityOptions.SetAsync();

            var result = await SignInManager.PasswordSignInAsync(
                LoginInput.UserNameOrEmailAddress,
                LoginInput.Password,
                LoginInput.RememberMe,
                true
            );

            await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
            {
                Identity = IdentitySecurityLogIdentityConsts.Identity,
                Action = result.ToIdentitySecurityLogAction(),
                UserName = LoginInput.UserNameOrEmailAddress
            });

            if (result.RequiresTwoFactor)
            {
                return await TwoFactorLoginResultAsync();
            }

            if (result.IsLockedOut)
            {
                Alerts.Warning(L["UserLockedOutMessage"]);
                return Page();
            }

            if (result.IsNotAllowed)
            {
                Alerts.Warning(L["LoginIsNotAllowed"]);
                return Page();
            }

            if (!result.Succeeded)
            {
                Alerts.Danger(L["InvalidUserNameOrPassword"]);
                return Page();
            }

            //TODO: Find a way of getting user's id from the logged in user and do not query it again like that!
            var user = await UserManager.FindByNameAsync(LoginInput.UserNameOrEmailAddress) ??
                       await UserManager.FindByEmailAsync(LoginInput.UserNameOrEmailAddress);
            Debug.Assert(user != null, nameof(user) + " != null");


            var userPermissions = await _permissionManager.GetAllForUserAsync(user.Id);
            var grantedPermissions = userPermissions.Where(a => a.IsGranted).ToList();
            if (grantedPermissions.Any(p => p.Name == BaharanPermissions.Personnels.UserMenu))
            {
                return RedirectSafely("~/Profile");
            }

            return RedirectSafely(ReturnUrl, ReturnUrlHash);
        }
    }
}
