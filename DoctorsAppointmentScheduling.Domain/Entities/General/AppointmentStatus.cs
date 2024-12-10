using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Domain.Entities.General
{
    [Table("AppointmentStatuses", Schema = "General")]

    public class AppointmentStatus
    {
        public long Id { get; set; }
        [MaxLength(100)]
        public string StatusName { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
