using Baharan.Documents;
using Baharan.Experiences;
using Baharan.Files;
using Baharan.Personnels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
namespace Baharan.Web.Pages.Profile
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IPersonnelAppService _personnelAppService;
        private readonly UserManager<Volo.Abp.Identity.IdentityUser> _userManager;
        private readonly IFileAppService _fileAppService;
        private readonly IExperienceAppService _experienceAppService;
        [BindProperty]
        public ProfileViewModel Profile { get; set; } = new();
        public IndexModel(IPersonnelAppService personnelAppService,
            UserManager<Volo.Abp.Identity.IdentityUser> userManager,
            IFileAppService fileAppService,
            IExperienceAppService experienceAppService)
        {
            _personnelAppService = personnelAppService;
            _userManager = userManager;
            _fileAppService = fileAppService;
            _experienceAppService = experienceAppService;
        }
        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Profile.Personnel = await _personnelAppService.GetByUserId(user.Id);
            //Profile.Document = await _fileAppService.GetPersonelDocuments(Profile.Personnel.Id);
            var docs = _fileAppService.GetPersonelDocumentsUrl(Profile.Personnel.Id);
            Profile.Document = new DocumentDto
            {
                NationalCart = docs.Item1,
                BirthCertificate = docs.Item2,
            };
            Profile.Experiences = await _experienceAppService.GetAllByPersonnelIdAsync(new GetExperienceListDto
            {
                MaxResultCount = 10,
                PersonnelId = Profile.Personnel.Id
            });
        }
    }
    public class ProfileViewModel
    {
        public PersonnelDto Personnel { get; set; }
        public DocumentDto Document { get; set; }
        public PagedResultDto<ExperienceDto> Experiences { get; set; }
    }
}
