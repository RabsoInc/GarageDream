using Models.BaseModels.System;
using Models.InternalViewModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IDapper
    {
        public bool CustomerHasContactDetails(Guid CustomerId, string ConnectionString);
        public bool CustomerHasAddress(Guid CustomerId, string ConnectionString);
        public bool CustomerHasVehicles(Guid CustomerId, string ConnectionString);
        public List<CustomerIndexInternalModel> GenerateCustomerIndexView(string ConnectionString);
        public List<DiarySlotViewModel> GenerateDiarySlotsIndexView(string ConnectionString, DiarySlotFilterViewModel Filters);
        public List<SystemJobIndexViewModel> GenerateSystemJobHistory(string ConnectionString);
        public void ManualRunSystemJob(SystemJob SystemJob, string ConnectionString);
        public void RunAllAutoSystemJobs(List<SystemJob> SystemJobs, string ConnectionString);



    }
}
