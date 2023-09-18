using Baharan.Personnels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
namespace Baharan.Web.Pages.Personnels
{
    public class CreateModalModel : BaharanPageModel
    {
        private readonly IPersonnelAppService _personnelAppService;
        [BindProperty]
        public CreatePersonnelViewModel Personnel { get; set; }
        public CreateModalModel(IPersonnelAppService personnelAppService)
        {
            _personnelAppService = personnelAppService;
        }
        public void OnGet()
        {
            Personnel = new();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();
            await _personnelAppService.CreateAsync(
                ObjectMapper.Map<CreatePersonnelViewModel, CreateUpdatePersonnelDto>(Personnel));
            return NoContent();
        }
    }
    public class CreatePersonnelViewModel
    {
        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(150)]
        public string LastName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string NationalCode { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
