using Baharan.Personnels;
using Baharan.Web.Core;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Web.Pages.Account;
namespace Baharan.Web.Pages.Account
{
    public class CustomRegisterModel : RegisterModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        [Required]
        public string RecaptchaToken { get; set; }
        private readonly IAccountAppService _accountAppService;
        private readonly GoogleReCaptchaService _googleReCaptchaService;
        private readonly IPersonnelAppService _personnelAppService;
        public CustomRegisterModel(IAccountAppService accountAppService,
            GoogleReCaptchaService googleReCaptchaService, IPersonnelAppService personnelAppService) : base(accountAppService)
        {
            _accountAppService = accountAppService;
            _googleReCaptchaService = googleReCaptchaService;
            _personnelAppService = personnelAppService;
        }
        public override async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var isValidCaptcha = await _googleReCaptchaService.VerifyToken(RecaptchaToken);
                if (!ModelState.IsValid || !isValidCaptcha)
                {
                    return Page();
                }
                await CheckSelfRegistrationAsync();
                await RegisterLocalUserAsync();
                return Redirect(ReturnUrl ?? "~/");
            }
            catch (BusinessException e)
            {
                Alerts.Danger(GetLocalizeExceptionMessage(e));
                return Page();
            }
        }
        protected override async Task RegisterLocalUserAsync()
        {
            ValidateModel();
            var userDto = await AccountAppService.RegisterAsync(
                new RegisterDto
                {
                    AppName = "MVC",
                    EmailAddress = Input.EmailAddress,
                    Password = Input.Password,
                    UserName = Input.UserName
                }
            );
            var user = await UserManager.GetByIdAsync(userDto.Id);
            await UserManager.AddToRoleAsync(user, GlobalConsts.DefaultRole);
            await _personnelAppService.CreateAsync(new CreateUpdatePersonnelDto { UserId = user.Id });
            await SignInManager.SignInAsync(user, isPersistent: true);
        }
    }
}
