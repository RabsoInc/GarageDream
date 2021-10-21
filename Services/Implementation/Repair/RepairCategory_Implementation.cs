using Models.BaseModels.Repair;
using Services.Interfaces.Repair;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.Repair
{
    public class RepairCategory_Implementation : IRepairCategory
    {
        private readonly GarageDreamDbContext db;

        public RepairCategory_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public RepairCategory CreateRecord(RepairCategory entity)
        {
            db.RepairCategories.Add(entity);
            return entity;
        }

        public RepairCategory Delete(RepairCategory entity)
        {
            db.RepairCategories.Remove(entity);
            return entity;
        }

        public IEnumerable<RepairCategory> GenerateDropDowns()
        {
            RepairCategory placeHolder = new RepairCategory
            {
                RepairCategoryId = Guid.Empty,
                RepairCategoryDescription = "** Please select a repair category **"
            };

            List<RepairCategory> result = ReturnAllRecords();
            result.Add(placeHolder);

            return result.OrderBy(x => x.RepairCategoryDescription);
        }

        public List<RepairCategory> ReturnAllRecords()
        {
            return db.RepairCategories
                .OrderBy(x => x.RepairCategoryDescription)
                .ToList();
        }

        public RepairCategory ReturnSingleRecord(string Description)
        {
            return db.RepairCategories
                .Where(x => x.RepairCategoryDescription == Description)
                .FirstOrDefault();
        }

        public RepairCategory ReturnSingleRecord(Guid Id)
        {
            return db.RepairCategories
                .Where(x => x.RepairCategoryId == Id)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public RepairCategory UpdateRecord(RepairCategory entity)
        {
            db.RepairCategories.Update(entity);
            return entity;
        }
    }
}
