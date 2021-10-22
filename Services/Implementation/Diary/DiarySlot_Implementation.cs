using Models.BaseModels.Diary;
using Models.BaseModels.Repair;
using Models.ViewModels.Diary;
using Services.Interfaces.Diary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.Diary
{
    public class DiarySlot_Implementation : IDiarySlot
    {
        private readonly GarageDreamDbContext db;

        public DiarySlot_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public void PopulateDiarySlots()
        {
            //Working Out
            List<DiaryWorkingDate> workingDates = db.DiaryWorkingDates.Where(x => x.Processed == false).ToList();
            List<WorkArea> workAreas = db.WorkAreas.OrderBy(x => x.WorkAreaDescription).ToList();

            //Loop Through Days
            foreach (var date in workingDates)
            {
                date.Processed = true;
                db.DiaryWorkingDates.Update(date);

                //Loop Through Work Arear's
                foreach (var workArea in workAreas)
                {
                    int slotsToCreate = workArea.DefaultUnits;
                    int counter = 1;

                    //Loop Through Slots
                    while (counter <= slotsToCreate)
                    {
                        DiarySlot diarySlot = new();
                        diarySlot.DiarySlotId = Guid.NewGuid();
                        diarySlot.DiaryWorkingDate = date;
                        diarySlot.WorkArea = workArea;
                        diarySlot.UnitNumber = counter;
                        db.DiarySlots.Add(diarySlot);

                        counter = counter + 1;
                    }
                }
            }

            db.SaveChanges();
        }

        public void RemoveExcessSlots(DiarySlotAdjustmentViewModel model)
        {
            //format the model data
            WorkArea workArea = db.WorkAreas
                .Where(x => x.WorkAreaDescription == model.WorkArea)
                .FirstOrDefault();

            DiaryWorkingDate workDate = db.DiaryWorkingDates
                .Where(x => x.WorkingDate == DateTime.Parse(model.WorkingDate))
                .FirstOrDefault();

            //Load the slots
            int slotCount = db.DiarySlots
                .Where(x => x.WorkArea == workArea && x.DiaryWorkingDate == workDate && x.RepairInstruction == null)
                .Count();

            var slots = db.DiarySlots
                .Where(x => x.WorkArea == workArea && x.DiaryWorkingDate == workDate && x.RepairInstruction == null)
                .OrderByDescending(x => x.UnitNumber)
                .Take(slotCount = model.RevisedSlots)
                .ToList();

            //Remove the slots and save changes
            foreach (var slot in slots)
            {
                db.DiarySlots.Remove(slot);
            }
            db.SaveChanges();              
        }
    }
}
