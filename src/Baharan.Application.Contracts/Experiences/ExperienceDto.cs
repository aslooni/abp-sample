using System;
using Volo.Abp.Application.Dtos;
namespace Baharan.Experiences
{
    public class ExperienceDto : AuditedEntityDto<Guid>
    {
        public string CompanyTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid PersonnelId { get; set; }
    }
}
