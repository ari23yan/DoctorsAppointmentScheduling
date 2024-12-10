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
    [Table("Patient", Schema = "General")]
    public class Patient:BaseEntity
    {
        public long Id { get; set; }
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        [MaxLength(10)]
        public string NationalCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public char Gender { get; set; } // male/female
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
    }
}
