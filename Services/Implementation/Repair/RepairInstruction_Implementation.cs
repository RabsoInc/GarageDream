using Microsoft.EntityFrameworkCore;
using Models.BaseModels.Repair;
using Services.Interfaces.Repair;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.Repair
{
    public class RepairInstruction_Implementation : IRepairInstruction
    {
        private readonly GarageDreamDbContext db;

        public RepairInstruction_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public RepairInstruction CreateRecord(RepairInstruction entity)
        {
            db.RepairInstructions.Add(entity);
            return entity;
        }

        public RepairInstruction Delete(RepairInstruction entity)
        {
            db.RepairInstructions.Remove(entity);
            return entity;
        }

        public List<RepairInstruction> ReturnAllRecords()
        {
            return db.RepairInstructions
                .Include(x => x.RepairHeader)
                .Include(x => x.RepairCategory)
                .ToList();
        }

        public RepairInstruction ReturnSingleRecord(string Description)
        {
            return ReturnAllRecords()
                .Where(x => x.Comments == Description)
                .FirstOrDefault();
        }

        public RepairInstruction ReturnSingleRecord(Guid Id)
        {
            return ReturnAllRecords()
                .Where(x => x.RepairInstructionId == Id)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public RepairInstruction UpdateRecord(RepairInstruction entity)
        {
            db.RepairInstructions.Update(entity);
            return entity;
        }
    }
}
