using Models.BaseModels.Repair;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation
{
    public class WorkArea_Implementation : IWorkArea
    {
        private readonly GarageDreamDbContext db;

        public WorkArea_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public WorkArea CreateRecord(WorkArea entity)
        {
            db.WorkAreas.Add(entity);
            return entity;
        }

        public WorkArea Delete(WorkArea entity)
        {
            db.WorkAreas.Remove(entity);
            return entity;
        }

        public IEnumerable<WorkArea> GenerateDropDowns()
        {
            WorkArea placeHolder = new WorkArea
            {
                WorkAreaId = Guid.Empty,
                WorkAreaDescription = "** Please select a work area **"
            };

            List<WorkArea> result = ReturnAllRecords();
            result.Add(placeHolder);

            return result.OrderBy(x => x.WorkAreaDescription);
        }

        public List<WorkArea> ReturnAllRecords()
        {
            return db.WorkAreas
                .OrderBy(x => x.WorkAreaDescription)
                .ToList();
        }

        public WorkArea ReturnSingleRecord(string Description)
        {
            return db.WorkAreas
                .Where(x => x.WorkAreaDescription == Description)
                .FirstOrDefault();
        }

        public WorkArea ReturnSingleRecord(Guid Id)
        {
            return db.WorkAreas
                .Where(x => x.WorkAreaId == Id)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public WorkArea UpdateRecord(WorkArea entity)
        {
            db.WorkAreas.Update(entity);
            return entity;
        }
    }
}
