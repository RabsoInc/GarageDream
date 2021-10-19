using Models.BaseModels.Vehicles;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation
{
    public class VehicleMake_Implementation : IVehicleMake
    {
        private readonly GarageDreamDbContext db;

        public VehicleMake_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public VehicleMake CreateRecord(VehicleMake entity)
        {
            db.VehicleMakes.Add(entity);
            return entity;
        }

        public VehicleMake Delete(VehicleMake entity)
        {
            db.VehicleMakes.Remove(entity);
            return entity;
        }

        public IEnumerable<VehicleMake> GenerateDropDowns()
        {
            VehicleMake placeHolder = new VehicleMake
            {
                VehicleMakeId = Guid.Empty,
                VehicleMakeDescription = "** Please select a make of vehicle **"
            };


            List<VehicleMake> result = ReturnAllRecords();
            result.Add(placeHolder);

            return result.OrderBy(x => x.VehicleMakeDescription);
        }

        public List<VehicleMake> ReturnAllRecords()
        {
            return db.VehicleMakes
                    .OrderBy(x => x.VehicleMakeDescription)
                    .ToList();
        }

        public VehicleMake ReturnSingleRecord(string Description)
        {
            return db.VehicleMakes
                    .Where(x => x.VehicleMakeDescription == Description)
                    .FirstOrDefault();
        }

        public VehicleMake ReturnSingleRecord(Guid Id)
        {
            return db.VehicleMakes
                    .Where(x => x.VehicleMakeId == Id)
                    .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public VehicleMake UpdateRecord(VehicleMake entity)
        {
            db.VehicleMakes.Update(entity);
            return entity;
        }
    }
}
