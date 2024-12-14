using DoctorsAppointmentScheduling.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Domain.Entities.Account
{
    [Table("RoleMenus", Schema = "Account")]

    public class RoleMenu : BaseEntity
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long MenuId { get; set; }
        public Role Role { get; set; }
        public Menu Menu { get; set; }
    }
}
