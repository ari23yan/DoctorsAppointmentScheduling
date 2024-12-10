using DoctorsAppointmentScheduling.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Domain.Entities.General
{
    [Table("Specialties", Schema = "General")]
    public class Specialties:BaseEntity
    {
        public long Id { get; set; }
        [MaxLength(500)]
        public required string SpecialtyName { get; set; }
        [MaxLength(10000)]
        public string? SpecialtyDescription { get; set; }   
        public bool IsGeneralSpecialty { get; set; } 
    }
}
