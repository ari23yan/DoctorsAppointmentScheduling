using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Domain.Entities.Common
{
    [Table("ActivityLogs", Schema = "Common")]

    public class ActivityLog
    {
        public long LogId { get; set; }
        [MaxLength(100)]
        public string TableName { get; set; }
        public long RecordId { get; set; }
        [MaxLength(100)]
        public long ActionTypeId { get; set; }
        public ActivityLogType ActivityLogType { get; set; }
        [MaxLength(5000)]
        public string ChangedFields { get; set; }

        public long ActionBy { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
