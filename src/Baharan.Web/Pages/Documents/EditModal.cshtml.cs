using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Baharan.Web.Pages.Documents
{
    public class EditModalModel : BaharanPageModel
    {
        private readonly IDocumentAppService _documentAppService;

        [BindProperty]
        public EditDocumentViewModel Document { get; set; }
        public EditModalModel(IDocumentAppService DocumentAppService)
        {
            _documentAppService = DocumentAppService;
        }
        public async void OnGet(Guid id)
        {
            var DocumentDto = await _documentAppService.GetAsync(id);
            Document = ObjectMapper.Map<DocumentDto, EditDocumentViewModel>(DocumentDto);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _documentAppService.UpdateAsync(
                Document.Id,
                ObjectMapper.Map<EditDocumentViewModel, CreateUpdateDocumentDto>(Document)
            );

            return NoContent();
        }
    }
    public class EditDocumentViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        [StringLength(500)]
        public string? NatopnalCodeImageUrl { get; set; }
        [StringLength(500)]
        public string? BirthCertificateImageUrl { get; set; }
        [Required]
        public Guid PersonnelId { get; set; }
    }
}
