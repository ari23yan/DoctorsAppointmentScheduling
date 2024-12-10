using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Domain.Enums
{
    public enum AppointmentStatusType:long
    {
        Reserved=1, 
        Confirmed,
        Cancelled
    }
}
