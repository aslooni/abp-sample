using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
namespace Baharan.Experiences
{
    public class Experience : AuditedAggregateRoot<Guid>
    {
        public required string CompanyTitle { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid PersonnelId { get; set; }
        public required Personnels.Personnel Personnel { get; set; }
    }
}
