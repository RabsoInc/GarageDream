using Models.BaseModels.System;
using Services.Interfaces.System;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.System
{
    public class SystemJob_Implementation : ISystemJob
    {
        private readonly GarageDreamDbContext db;

        public SystemJob_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public List<SystemJob> AllAutoRunSystemJobs()
        {
            return db.SystemJobs
                .Where(x => x.AutoRunOnStartUp == true)
                .ToList();
        }

        public SystemJob CreateRecord(SystemJob entity)
        {
            db.SystemJobs.Add(entity);
            return entity;
        }

        public SystemJob Delete(SystemJob entity)
        {
            db.SystemJobs.Remove(entity);
            return entity;
        }

        public List<SystemJob> ReturnAllRecords()
        {
            return db.SystemJobs
                .OrderBy(x => x.SystemJobDescription)
                .ToList();
        }

        public SystemJob ReturnSingleRecord(string Description)
        {
            return db.SystemJobs
                .Where(x => x.SystemJobDescription == Description)
                .FirstOrDefault();
        }

        public SystemJob ReturnSingleRecord(Guid Id)
        {
            return db.SystemJobs
                .Where(x => x.SystemJobId == Id)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public SystemJob UpdateRecord(SystemJob entity)
        {
            db.SystemJobs.Update(entity);
            return entity;
        }
    }
}
