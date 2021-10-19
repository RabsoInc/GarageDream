using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.BaseModels.CRM;
using Models.BaseModels.Diary;
using Models.BaseModels.Identity;
using Models.BaseModels.Repair;
using Models.BaseModels.System;
using Models.BaseModels.Vehicles;

namespace Services
{
    public class GarageDreamDbContext : IdentityDbContext<ApplicationUser>
    {
        public GarageDreamDbContext(DbContextOptions<GarageDreamDbContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactMethodType> ContactMethodTypes { get; set; }
        public DbSet<CustomerContactDetail> CustomerContactDetails { get; set; }
        public DbSet<RepairHeader> RepairHeader { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DiaryOption> DiaryOptions { get; set; }
        public DbSet<DiarySlot> DiarySlots { get; set; }
        public DbSet<DiaryWorkingDate> DiaryWorkingDates { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<RepairStatus> RepairStatuses { get; set; }
        public DbSet<SystemJob> SystemJobs { get; set; }
        public DbSet<SystemJobHistory> SystemJobHistories { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<WorkArea> WorkAreas { get; set; }
    }
}
