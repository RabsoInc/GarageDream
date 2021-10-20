using Models.BaseModels.Repair;
using Services.Interfaces.Repair;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.Repair
{
    public class RepairStatus_Implementation : IRepairStatus
    {
        private readonly GarageDreamDbContext db;

        public RepairStatus_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public string CalculateRepairStatusPerc(RepairStatus RepairStatus)
        {
            decimal maxRecords = db.RepairStatuses.Where(x => x.PrecedenceOrder != 99).Count();
            decimal perc = (RepairStatus.PrecedenceOrder / maxRecords) * 100;
            string result = decimal.ToInt32(perc).ToString()+"%";
            return result;
        }

        public RepairStatus CreateRecord(RepairStatus entity)
        {
            db.RepairStatuses.Add(entity);
            return entity;
        }

        public RepairStatus Delete(RepairStatus entity)
        {
            db.RepairStatuses.Remove(entity);
            return entity;
        }

        public List<RepairStatus> ReturnAllRecords()
        {
            return db.RepairStatuses
                .OrderBy(x => x.PrecedenceOrder)
                .ToList();
        }

        public RepairStatus ReturnSingleRecord(string Description)
        {
            return db.RepairStatuses
                .Where(x => x.RepairStatusDescription == Description)
                .FirstOrDefault();
        }

        public RepairStatus ReturnSingleRecord(Guid Id)
        {
            return db.RepairStatuses
                .Where(x => x.RepairStatusId == Id)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public RepairStatus UpdateRecord(RepairStatus entity)
        {
            db.RepairStatuses.Update(entity);
            return entity;
        }
    }
}
