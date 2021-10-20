using Models.BaseModels.System;
using System.Collections.Generic;

namespace Services.Interfaces.System
{
    public interface ISystemJobHistory
    {
        public SystemJobHistory CreateNewRecord(SystemJobHistory SystemJobHistory);
        public List<SystemJobHistory> ReturnAllRecords();
        public int SaveChanges();
    }
}
