using DoctorsAppointmentScheduling.Application.Security;
using DoctorsAppointmentScheduling.Data.Context;
using DoctorsAppointmentScheduling.Domain.Entities.Account;
using DoctorsAppointmentScheduling.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IPasswordHasher _passwordHasher;
        public UserRepository(IPasswordHasher passwordHasher, AppDbContext context) : base(context)
        {
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> CheckUserHavePermission(long roleId, long permissionId)
        {
            return await Context.RolePermissions.AnyAsync(x => x.RoleId.Equals(roleId) && x.PermissionId.Equals(permissionId));
        }

    }
}
