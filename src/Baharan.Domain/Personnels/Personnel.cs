using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Baharan.Personnels
{
    public class Personnel : AuditedAggregateRoot<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NationalCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public required IdentityUser User { get; set; }
    }
}
