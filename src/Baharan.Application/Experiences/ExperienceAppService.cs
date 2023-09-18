using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
namespace Baharan.Experiences
{
    public class ExperienceAppService : CrudAppService<Experience, ExperienceDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateExperienceDto>, IExperienceAppService
    {
        public ExperienceAppService(IRepository<Experience, Guid> repository) : base(repository)
        {
        }
        public async Task<PagedResultDto<ExperienceDto>> GetAllByPersonnelIdAsync(GetExperienceListDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(a => a.PersonnelId == input.PersonnelId);

            var totalCount = await AsyncExecuter.CountAsync(query);
            query = query.PageBy(input);

            var experienceDto = ObjectMapper.Map<List<Experience>, List<ExperienceDto>>(await AsyncExecuter.ToListAsync(query));
            return new PagedResultDto<ExperienceDto>(totalCount, experienceDto);
        }
    }
}
