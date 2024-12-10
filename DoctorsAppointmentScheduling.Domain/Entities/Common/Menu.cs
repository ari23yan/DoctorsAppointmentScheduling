using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorsAppointmentScheduling.Domain.Entities.Account;

namespace DoctorsAppointmentScheduling.Domain.Entities.Common
{
    [Table("Menus", Schema = "Common")]
    public class Menu
    {
        public long Id { get; set; }
        [MaxLength(256)]
        public string? Name { get; set; }
        [MaxLength(256)]
        public string? Name_Farsi { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public string? Link { get; set; }
        public ICollection<Role> RolePermissions { get; set; }
        public Guid? SubMenuId { get; set; }
    }
}
