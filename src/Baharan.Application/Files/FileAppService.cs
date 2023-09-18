using Baharan.Documents;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Users;
namespace Baharan.Files
{
    [Authorize]
    public class FileAppService : ApplicationService, IFileAppService
    {
        private readonly IBlobContainer _blobContainer;
        public FileAppService(IBlobContainerFactory blobContainerFactory)
        {
            _blobContainer = blobContainerFactory.Create("documents");
        }
        public async Task SaveAsync(string fileName, byte[] streamContent)
        {
            await _blobContainer.SaveAsync(fileName, streamContent, overrideExisting: true);
        }
        public async Task<byte[]> GetAsync()
        {
            var blobName = CurrentUser.GetId().ToString();
            return await _blobContainer.GetAllBytesOrNullAsync(blobName);
        }
        [AllowAnonymous, RemoteService(false)]
        public async Task<DocumentDto> GetPersonelDocuments(Guid id)
        {
            var result = new DocumentDto();
            var nationalCartBlobName = $"{id}-{GlobalConsts.NationalCart}.jpg";
            var birthCertificateBlobName = $"{id}-{GlobalConsts.BirthCertificate}.jpg";
            var nationalCartContent = await _blobContainer.GetOrNullAsync(nationalCartBlobName);
            var birthCertificateContent = await _blobContainer.GetOrNullAsync(birthCertificateBlobName);
            //if (nationalCartContent != null)
            //{
            //    result.NationalCart = new RemoteStreamContent(nationalCartContent, nationalCartBlobName);
            //}
            //if (birthCertificateContent != null)
            //{
            //    result.BirthCertificate = new RemoteStreamContent(birthCertificateContent, birthCertificateBlobName);
            //}
            return result;
        }
        public (string, string) GetPersonelDocumentsUrl(Guid id)
        {
            var nationalCartBlobName = $"host/documents/{id}-{GlobalConsts.NationalCart}.jpg";
            var birthCertificateBlobName = $"host/documents/{id}-{GlobalConsts.BirthCertificate}.jpg";
            return (nationalCartBlobName, birthCertificateBlobName);
        }
    }
}
