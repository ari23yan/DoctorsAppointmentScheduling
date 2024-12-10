using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Domain.Entities.Common
{
    public class BaseEntity
    {
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public bool IsModified { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public long? CreatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
