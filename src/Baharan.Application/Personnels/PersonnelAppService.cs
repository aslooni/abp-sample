using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
namespace Baharan.Personnels
{
    [Authorize]
    public class PersonnelAppService : CrudAppService<Personnel, PersonnelDto, Guid, PagedAndSortedResultRequestDto, CreateUpdatePersonnelDto>, IPersonnelAppService
    {
        public PersonnelAppService(IRepository<Personnel, Guid> repository) : base(repository)
        {
        }
        public async Task<PersonnelDto> GetByUserId(Guid id)
        {
            var model = await Repository.FirstOrDefaultAsync(x => x.UserId == id);
            return ObjectMapper.Map<Personnel, PersonnelDto>(model);
        }
        [AllowAnonymous, RemoteService(false)]
        public override async Task<PersonnelDto> CreateAsync(CreateUpdatePersonnelDto input)
        {
            var existPersonnel = await GetByUserId(input.UserId);
            return existPersonnel != null ? existPersonnel : await base.CreateAsync(input);
        }
    }
}
