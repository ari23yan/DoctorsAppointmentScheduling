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
    [Table("Doctors", Schema = "General")]
    public class Doctor:BaseEntity
    {
        public long Id { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(128)]

        public string? LastName { get; set; }
        [MaxLength(256)]

        public string? NoNezam { get; set; }
        [MaxLength(20)]

        public string? NationalCode { get; set; }
        [MaxLength(20)]

        public string? PhoneNumber { get; set; }
        [MaxLength(500)]

        public long SpecialtyId { get; set; } // Mandatory Specialty
        public Specialties Specialty { get; set; }

        public long? GeneralSpecialtyId { get; set; } // Optional General Specialty
        public Specialties? GeneralSpecialty { get; set; }

        public int? GroupCode { get; set; }

    }
}
