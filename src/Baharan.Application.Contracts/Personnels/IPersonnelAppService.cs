using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace Baharan.Personnels
{
    public interface IPersonnelAppService : ICrudAppService<PersonnelDto, Guid, PagedAndSortedResultRequestDto, CreateUpdatePersonnelDto>
    {
        Task<PersonnelDto> GetByUserId(Guid id);
    }
}
