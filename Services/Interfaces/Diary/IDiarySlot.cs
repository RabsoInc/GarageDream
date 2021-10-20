using Models.ViewModels.Diary;

namespace Services.Interfaces.Diary
{
    public interface IDiarySlot
    {
        public void PopulateDiarySlots();
        public void RemoveExcessSlots(DiarySlotAdjustmentViewModel model);
    }
}
