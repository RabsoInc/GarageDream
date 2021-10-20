using Microsoft.EntityFrameworkCore;
using Models.BaseModels.Repair;
using Models.ViewModels.Repair;
using Services.Interfaces.Repair;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.Repair
{
    public class RepairHeader_Implementation : IRepairHeader
    {
        private readonly GarageDreamDbContext db;

        public RepairHeader_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }
        public RepairHeader CreateRecord(RepairHeader entity)
        {
            db.RepairHeader.Add(entity);
            return entity;
        }

        public RepairHeader Delete(RepairHeader entity)
        {
            db.RepairHeader.Remove(entity);
            return entity;
        }

        public List<RepairHeader> ReturnAllRecords()
        {
            return db.RepairHeader
                    .Include(x => x.Vehicle)
                    .Include(x => x.Vehicle.VehicleMake)
                    .Include(x => x.Vehicle.VehicleModel)
                    .Include(x => x.Vehicle.Customer)
                    .Include(x => x.Vehicle.Customer.Title)
                    .Include(x => x.RepairStatus)
                    .OrderBy(x => x.Vehicle.Customer.LastName)
                    .ToList();
        }

        public List<RepairCustomSelectViewModel> ReturnAllRecordsByCustomerId_CustomDisplay(Guid CustomerId)
        {
            List<RepairCustomSelectViewModel> result = new();

            List<RepairHeader> repairs = db.RepairHeader
                .Where(x => x.Vehicle.Customer.CustomerId == CustomerId)
                .Include(x => x.Vehicle)
                .Include(x => x.Vehicle.VehicleMake)
                .Include(x => x.Vehicle.VehicleModel)
                .Include(x => x.RepairStatus)
                .OrderByDescending(x => x.JobBooked)
                .ToList();

            foreach (var repair in repairs)
            {
                var x = new RepairCustomSelectViewModel();
                x.RepairId = repair.RepairHeaderId;
                x.SelectDescription = repair.Vehicle.VehicleMake.VehicleMakeDescription + " "
                    + repair.Vehicle.VehicleModel.VehicleModelDescription + " "
                    + repair.Vehicle.RegistrationNumber + " | Booked: "
                    + repair.JobBooked.ToShortDateString();
                result.Add(x);
            }

            return result;
        }

        public RepairHeader ReturnSingleRecord(string Description)
        {
            return ReturnAllRecords()
                .Where(x => x.Vehicle.RegistrationNumber == Description)
                .FirstOrDefault();
        }

        public RepairHeader ReturnSingleRecord(Guid Id)
        {
            return ReturnAllRecords()
                .Where(x => x.RepairHeaderId == Id)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public RepairHeader UpdateRecord(RepairHeader entity)
        {
            db.RepairHeader.Update(entity);
            return entity;
        }
    }
}
