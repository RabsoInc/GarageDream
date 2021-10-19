using Models.ViewModels;

namespace Services.Interfaces
{
    public interface IDiarySlot
    {
        public void PopulateDiarySlots();
        public void RemoveExcessSlots(DiarySlotAdjustmentViewModel model);
    }
}
