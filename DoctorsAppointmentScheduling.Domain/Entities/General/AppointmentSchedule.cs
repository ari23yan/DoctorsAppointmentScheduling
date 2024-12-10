using DoctorsAppointmentScheduling.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Domain.Entities.General
{
    [Table("AppointmentSchedule", Schema = "General")]

    public class AppointmentSchedule:BaseEntity
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int MaxAppointments { get; set; }
        public int RemainingAppointments { get; set; }
        public long AppointmentStatusId { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
