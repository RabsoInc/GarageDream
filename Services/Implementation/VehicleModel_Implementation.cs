using Models.BaseModels.Vehicles;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation
{
    public class VehicleModel_Implementation : IVehicleModel
    {
        private readonly GarageDreamDbContext db;

        public VehicleModel_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public VehicleModel CreateRecord(VehicleModel entity)
        {
            db.VehicleModels.Add(entity);
            return entity;
        }

        public VehicleModel Delete(VehicleModel entity)
        {
            db.VehicleModels.Remove(entity);
            return entity;
        }

        public IEnumerable<VehicleModel> GenerateDropDowns()
        {
            VehicleModel placeHolder = new VehicleModel
            {
                VehicleModelId = Guid.Empty,
                VehicleModelDescription = "** Please select a model of vehicle **"
            };


            List<VehicleModel> result = ReturnAllRecords();
            result.Add(placeHolder);

            return result.OrderBy(x => x.VehicleModelDescription);
        }

        public List<VehicleModel> ReturnAllRecords()
        {
            return db.VehicleModels
                    .OrderBy(x => x.VehicleModelDescription)
                    .ToList();
        }

        public List<VehicleModel> ReturnAllRecordsByVehicleMake(Guid VehicleMakeId)
        {
            return db.VehicleModels
           .Where(x => x.VehicleMake.VehicleMakeId == VehicleMakeId)
           .OrderBy(x => x.VehicleModelDescription)
           .ToList();
        }

        public VehicleModel ReturnSingleRecord(string Description)
        {
            return db.VehicleModels
                    .Where(x => x.VehicleModelDescription == Description)
                    .FirstOrDefault();
        }

        public VehicleModel ReturnSingleRecord(Guid Id)
        {
            return db.VehicleModels
                    .Where(x => x.VehicleModelId == Id)
                    .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public VehicleModel UpdateRecord(VehicleModel entity)
        {
            db.VehicleModels.Update(entity);
            return entity;
        }

    }
}
