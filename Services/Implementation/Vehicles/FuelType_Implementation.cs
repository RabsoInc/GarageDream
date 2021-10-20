using Models.BaseModels.Vehicles;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.Vehicles
{
    public class FuelType_Implementation : IFuelType
    {
        private readonly GarageDreamDbContext db;

        public FuelType_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public FuelType CreateRecord(FuelType entity)
        {
            db.FuelTypes.Add(entity);
            return entity;
        }

        public FuelType Delete(FuelType entity)
        {
            db.FuelTypes.Remove(entity);
            return entity;
        }

        public IEnumerable<FuelType> GenerateDropDowns()
        {
            FuelType placeHolder = new FuelType
            {
                FuelTypeId = Guid.Empty,
                FuelTypeDescription = "** Please select a gender **"
            };

            List<FuelType> result = ReturnAllRecords();
            result.Add(placeHolder);

            return result.OrderBy(x => x.FuelTypeDescription);
        }

        public List<FuelType> ReturnAllRecords()
        {
            return db.FuelTypes
                .OrderBy(x => x.FuelTypeDescription)
                .ToList();
        }

        public FuelType ReturnSingleRecord(string Description)
        {
            return db.FuelTypes
                .Where(x => x.FuelTypeDescription == Description)
                .FirstOrDefault();
        }

        public FuelType ReturnSingleRecord(Guid Id)
        {
            return db.FuelTypes
                .Where(x => x.FuelTypeId == Id)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public FuelType UpdateRecord(FuelType entity)
        {
            db.FuelTypes.Update(entity);
            return entity;
        }
    }
}
