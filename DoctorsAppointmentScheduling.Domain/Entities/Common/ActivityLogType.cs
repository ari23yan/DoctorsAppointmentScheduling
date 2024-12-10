using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Domain.Entities.Common
{
    [Table("ActivityLogTypes", Schema = "Common")]

    public class ActivityLogType
    {
        public long Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
