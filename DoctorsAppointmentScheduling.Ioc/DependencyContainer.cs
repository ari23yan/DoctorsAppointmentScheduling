using DoctorsAppointmentScheduling.Application.Security;
using DoctorsAppointmentScheduling.Application.Senders;
using DoctorsAppointmentScheduling.Application.Services.Implementations;
using DoctorsAppointmentScheduling.Application.Services.Interfaces;
using DoctorsAppointmentScheduling.Data.Repositories;
using DoctorsAppointmentScheduling.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Ioc
{
    public static class DependencyContainer
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ISender, Sender>();
        }
    }
}
