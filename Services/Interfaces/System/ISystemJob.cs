using Models.BaseModels.System;
using Services.Templates;
using System.Collections.Generic;

namespace Services.Interfaces.System
{
    public interface ISystemJob : IGenericOperations_PK_GUID<SystemJob>
    {
        public List<SystemJob> AllAutoRunSystemJobs();
    }
}
