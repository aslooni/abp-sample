using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System;
using Baharan.Personnels;
using System.Threading.Tasks;

namespace Baharan.Web.Pages.Personnels
{
    public class EditModalModel : BaharanPageModel
    {
        private readonly IPersonnelAppService _personnelAppService;

        [BindProperty]
        public EditPersonnelViewModel Personnel { get; set; }
        public EditModalModel(IPersonnelAppService personnelAppService)
        {
            _personnelAppService = personnelAppService;
        }
        public async void OnGet(Guid id)
        {
            var personnelDto = await _personnelAppService.GetAsync(id);
            Personnel = ObjectMapper.Map<PersonnelDto, EditPersonnelViewModel>(personnelDto);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();

            await _personnelAppService.UpdateAsync(
                Personnel.Id,
                ObjectMapper.Map<EditPersonnelViewModel, CreateUpdatePersonnelDto>(Personnel)
            );
            return NoContent(); 
        }
    }
    public class EditPersonnelViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        [HiddenInput]
        public Guid UserId { get; set; }
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
