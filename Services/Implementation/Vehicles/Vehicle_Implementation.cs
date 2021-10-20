using Microsoft.EntityFrameworkCore;
using Models.BaseModels.Vehicles;
using Models.ViewModels.Vehicles;
using Services.Interfaces.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.Vehicles
{
    public class Vehicle_Implementation : IVehicle
    {
        private readonly GarageDreamDbContext db;

        public Vehicle_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public Vehicle CreateRecord(Vehicle entity)
        {
            db.Vehicles.Add(entity);
            return entity;
        }

        public Vehicle Delete(Vehicle entity)
        {
            db.Vehicles.Remove(entity);
            return entity;
        }

        public List<Vehicle> ReturnAllRecords()
        {
            return db.Vehicles
                .OrderBy(x => x.VehicleId)
                .ToList();
        }

        public List<Vehicle> ReturnAllRecordsByCustomerId(Guid CustomerId)
        {
            return db.Vehicles
                .Where(x => x.Customer.CustomerId == CustomerId)
                .OrderBy(x => x.VehicleId)
                .ToList();
        }

        public List<VehicleCustomSelectViewModel> ReturnAllRecordsByCustomerId_CustomDisplay(Guid CustomerId)
        {
           List< VehicleCustomSelectViewModel> result = new();

            List<Vehicle> vehicles = db.Vehicles
                .Where(x => x.Customer.CustomerId == CustomerId)
                .Include(x => x.VehicleMake)
                .Include(x => x.VehicleModel)
                .OrderBy(x => x.VehicleId)
                .ToList();

            foreach (var vehicle in vehicles)
            {
                var x = new VehicleCustomSelectViewModel();
                x.VehicleId = vehicle.VehicleId;
                x.SelectDescription = vehicle.VehicleMake.VehicleMakeDescription + " "
                    + vehicle.VehicleModel.VehicleModelDescription + " "
                    + vehicle.RegistrationNumber;
                result.Add(x);
            }

            return result;
        }

        public Vehicle ReturnSingleRecord(string Description)
        {
            return db.Vehicles
                .Where(x => x.RegistrationNumber == Description)
                .FirstOrDefault();
        }

        public Vehicle ReturnSingleRecord(Guid Id)
        {
            return db.Vehicles
                .Where(x => x.VehicleId == Id)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public Vehicle UpdateRecord(Vehicle entity)
        {
            db.Vehicles.Update(entity);
            return entity;
        }
    }
}
