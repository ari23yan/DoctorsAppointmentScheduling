using DoctorsAppointmentScheduling.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Domain.Entities.Account
{
    [Table("RolePermissions", Schema = "Account")]

    public class RolePermission : BaseEntity
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
