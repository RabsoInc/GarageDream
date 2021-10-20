using Models.BaseModels.System;
using Services.Interfaces.System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.System
{
    public class SystemJobHistory_Implementation : ISystemJobHistory
    {
        private readonly GarageDreamDbContext db;

        public SystemJobHistory_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public SystemJobHistory CreateNewRecord(SystemJobHistory SystemJobHistory)
        {
            db.SystemJobHistories.Add(SystemJobHistory);
            return SystemJobHistory;
        }

        public List<SystemJobHistory> ReturnAllRecords()
        {
            return db.SystemJobHistories
                .OrderBy(x => x.DateExecuted)
                .ToList();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
