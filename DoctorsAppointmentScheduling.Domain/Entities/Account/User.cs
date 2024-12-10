using DoctorsAppointmentScheduling.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DoctorsAppointmentScheduling.Domain.Entities.Account
{
    [Table("Users", Schema = "Account")]
    public class User : BaseEntity
    {
        public long Id { get; set; }

        [MaxLength(64)]
        public string? FirstName { get; set; }
        [MaxLength(64)]
        public string? LastName { get; set; }
        [MaxLength(64)]
        public string Username { get; set; }
        [MaxLength(128)]
        public string Password { get; set; }
        [MaxLength(15)]
        public string? PhoneNumber { get; set; }
        public bool? PhoneNumberConfirmed { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime? LastLoginDate { get; set; }
        //public UserDetail UserDetail { get; set; }
        public ICollection<Otp> Otps { get; set; } = new List<Otp>();
    }
}
