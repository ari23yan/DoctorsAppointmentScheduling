using DoctorsAppointmentScheduling.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Domain.Entities.Account
{
    [Table("Otps", Schema = "Account")]
    public class Otp
    {
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        public User User { get; set; }
        [Required]
        [MaxLength(6)]
        public string OtpCode { get; set; }
        [Required]
        public DateTime ExpirationTime { get; set; } = DateTime.Now.AddMinutes(2);
        public bool IsUsed { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
