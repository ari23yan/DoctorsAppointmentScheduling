using DoctorsAppointmentScheduling.Domain.Entities.Account;
using DoctorsAppointmentScheduling.Domain.Entities.Common;
using DoctorsAppointmentScheduling.Domain.Entities.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Data.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        // Account

        public DbSet<User> Users {  get; set; } 
        public DbSet<Permission> Permissions {  get; set; } 
        public DbSet<Role> Roles {  get; set; } 
        public DbSet<RoleMenu> RoleMenus {  get; set; } 
        public DbSet<RolePermission> RolePermissions {  get; set; } 


        // General
        public DbSet<AppointmentReservation>  AppointmentReservations {  get; set; } 
        public DbSet<AppointmentSchedule>  AppointmentSchedules {  get; set; } 
        public DbSet<AppointmentStatus>  AppointmentStatuses {  get; set; } 
        public DbSet<Doctor>  Doctors {  get; set; } 
        public DbSet<Patient>  Patients {  get; set; } 
        public DbSet<Specialties>  Specialties {  get; set; }

        //Common
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<ActivityLogType> ActivityLogTypes { get; set; }
        public DbSet<Menu> Menus { get; set; }

    }
}
