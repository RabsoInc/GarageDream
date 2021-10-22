using Models.BaseModels.System;
using Models.InternalViewModels;
using Models.ViewModels.Diary;
using Models.ViewModels.System;
using System;
using System.Collections.Generic;

namespace Services.Interfaces.Dapper
{
    public interface IDapper
    {
        public bool CustomerHasContactDetails(Guid CustomerId, string ConnectionString);
        public bool CustomerHasAddress(Guid CustomerId, string ConnectionString);
        public bool CustomerHasVehicles(Guid CustomerId, string ConnectionString);
        public List<CustomerIndexInternalModel> GenerateCustomerIndexView(string ConnectionString);
        public List<DiarySlotsAvailableInternalModel> GetAvailableDiarySlots(string ConnectionString, int UnitsRequired, string WorkAreaDescription);
        public List<DiarySlotViewModel> GenerateDiarySlotsIndexView(string ConnectionString, DiarySlotFilterViewModel Filters);
        public void ConfirmAndBookDiarySlots(string ConnectionString, int Units, string BookedDate, string WorkAreaDescription, Guid RepairInstructionId);
        public List<SystemJobIndexViewModel> GenerateSystemJobHistory(string ConnectionString);
        public void ManualRunSystemJob(SystemJob SystemJob, string ConnectionString);
        public void SetRepairHeaderStatus(string ConnectionString, Guid RepairHeaderId);
        public void RunAllAutoSystemJobs(List<SystemJob> SystemJobs, string ConnectionString);



    }
}
