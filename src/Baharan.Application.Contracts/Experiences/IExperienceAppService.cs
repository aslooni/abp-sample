using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Baharan.Experiences
{
    public interface IExperienceAppService : ICrudAppService<ExperienceDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateExperienceDto>
    {
        Task<PagedResultDto<ExperienceDto>> GetAllByPersonnelIdAsync(GetExperienceListDto input);
    }
}
