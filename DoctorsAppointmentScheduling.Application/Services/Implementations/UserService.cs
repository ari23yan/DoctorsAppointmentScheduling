using DoctorsAppointmentScheduling.Application.Services.Interfaces;
using DoctorsAppointmentScheduling.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> CheckUserHavePermission(long roleId, long permissionId)
        {
            return await _userRepository.CheckUserHavePermission(roleId, permissionId);
        }
    }
}
