using Models.BaseModels.Vehicles;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation
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
