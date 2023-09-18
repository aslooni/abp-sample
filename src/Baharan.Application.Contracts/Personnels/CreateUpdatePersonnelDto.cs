using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Baharan.Personnels
{
    public class CreateUpdatePersonnelDto
    {
        public Guid Id { get; set; }
        //[Required]
        [StringLength(150)]
        public string? FirstName { get; set; }
        //[Required]
        [StringLength(150)]
        public string? LastName { get; set; }
        //[Required]
        [StringLength(10, MinimumLength = 10)]
        public string? NationalCode { get; set; }
        //[Required]    
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public Guid UserId { get; set; }

    }
}
