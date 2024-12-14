using DoctorsAppointmentScheduling.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> CheckUserHavePermission(long roleId, long permissionId);
    }
}
