using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
namespace Baharan.Personnels
{
    public class PersonnelDto : AuditedEntityDto<Guid>
    {
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string NationalCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public Guid UserId { get; set; }
    }
}
