using Baharan.Documents;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Baharan.Files
{
    public interface IFileAppService : IApplicationService
    {
        Task SaveAsync(string fileName, byte[] streamContent);
        Task<byte[]> GetAsync();
        Task<DocumentDto> GetPersonelDocuments(Guid id);
        (string, string) GetPersonelDocumentsUrl(Guid id);
    }
}
