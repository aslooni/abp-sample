using System;
using Volo.Abp.Application.Dtos;
namespace Baharan.Experiences
{
    public class GetExperienceListDto : PagedResultRequestDto
    {
        public Guid PersonnelId { get; set; }
    }
}
