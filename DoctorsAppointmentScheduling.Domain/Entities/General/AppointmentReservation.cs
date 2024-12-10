using DoctorsAppointmentScheduling.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Domain.Entities.General
{
    [Table("AppointmentReservations", Schema = "General")]

    public class AppointmentReservation:BaseEntity
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public Patient Patient { get; set; }
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int AppointmentStatusId { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
