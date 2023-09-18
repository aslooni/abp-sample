using Baharan.Files;
using Baharan.Personnels;
using Baharan.Web.Helpers;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
namespace Baharan.Web.Pages.Documents
{
    [Authorize]
    public class CreateModalModel : BaharanPageModel
    {
        private readonly IFileAppService _fileAppService;
        private readonly IPersonnelAppService _personnelAppService;
        [BindProperty]
        public CreateDocumentViewModel Document { get; set; }
        public CreateModalModel(IFileAppService fileAppService, IPersonnelAppService personnelAppService)
        {
            _fileAppService = fileAppService;
            _personnelAppService = personnelAppService;
        }
        public async void OnGet()
        {
            var currentPersonnel = await _personnelAppService.GetByUserId(CurrentUser.Id.Value);
            Document = new();
            //return NoContent();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var currentPersonnel = await _personnelAppService.GetByUserId(CurrentUser.Id.Value);
                if (currentPersonnel != null)
                {
                    if (Document.NationalCartFile != null && Document.NationalCartFile.Length > 0)
                    {
                        var documentBytes = await Document.NationalCartFile.GetAllBytesAsync();
                        //string extention = Path.GetExtension(Document.NationalCartFile.FileName);
                        string fileName = $"{currentPersonnel.Id}-{GlobalConsts.NationalCart}.jpg";
                        await _fileAppService.SaveAsync(fileName, documentBytes);
                    }
                    if (Document.BirthCertificate != null && Document.BirthCertificate.Length > 0)
                    {
                        var documentBytes = await Document.BirthCertificate.GetAllBytesAsync();
                        //string extention = Path.GetExtension(Document.BirthCertificate.FileName);
                        string fileName = $"{currentPersonnel.Id}-{GlobalConsts.BirthCertificate}.jpg";
                        await _fileAppService.SaveAsync(fileName, documentBytes);
                    }
                }
                //await using var memoryStream = new MemoryStream();
                //if (Document.NationalCartFile != null && Document.NationalCartFile.Length > 0)
                //{
                //    await Document.NationalCartFile.CopyToAsync(memoryStream);
                //    memoryStream.Position = 0;
                //    var nationalCartStreamContent = new RemoteStreamContent(memoryStream,
                //        fileName: Document.NationalCartFile.FileName, contentType: Document.NationalCartFile.ContentType);
                //    await _fileAppService.SaveAsync(PersonnelId, nationalCartStreamContent);
                //}
                return NoContent();
            }
            catch (Exception exception)
            {
                ShowAlert(exception);
                return Page();
            }
        }
    }
    public class CreateDocumentViewModel
    {
        [CanBeNull]
        [DataType(DataType.Upload)]
        [MaxFileSize(GlobalConsts.MaxProfilePictureFileSize)]
        [AllowedExtensions(new string[] { ".jpg" })]
        public IFormFile? NationalCartFile { get; set; }
        [CanBeNull]
        [DataType(DataType.Upload)]
        [MaxFileSize(GlobalConsts.MaxProfilePictureFileSize)]
        [AllowedExtensions(new string[] { ".jpg" })]
        public IFormFile? BirthCertificate { get; set; }
    }
}
