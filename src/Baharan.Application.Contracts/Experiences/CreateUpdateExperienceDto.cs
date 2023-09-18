using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Baharan.Experiences
{
    public class CreateUpdateExperienceDto
    {
        public Guid Id { get; set; }
        [Required, StringLength(150)]
        public string CompanyTitle { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        [Required]
        public Guid PersonnelId { get; set; }
    }
}
