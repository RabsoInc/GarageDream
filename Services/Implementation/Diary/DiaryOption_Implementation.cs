using Models.BaseModels.Diary;
using Services.Interfaces.Diary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.Diary
{
    public class DiaryOption_Implementation : IDiaryOption
    {
        private readonly GarageDreamDbContext db;

        public DiaryOption_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public DiaryOption CreateRecord(DiaryOption entity)
        {
            db.DiaryOptions.Add(entity);
            return entity;
        }

        public DiaryOption Delete(DiaryOption entity)
        {
            db.DiaryOptions.Remove(entity);
            return entity;
        }

        public DiaryOption LoadDefaultValue()
        {
            return db.DiaryOptions
                .FirstOrDefault();
        }

        public List<DiaryOption> ReturnAllRecords()
        {
            return db.DiaryOptions
                .OrderBy(x => x.DiaryOptionId)
                .ToList();
        }

        public DiaryOption ReturnSingleRecord(string Description)
        {
            return db.DiaryOptions
                .Where(x => x.DiaryOptionId.ToString() == Description)
                .FirstOrDefault();
        }

        public DiaryOption ReturnSingleRecord(Guid Id)
        {
            return db.DiaryOptions
                .Where(x => x.DiaryOptionId == Id)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public DiaryOption UpdateRecord(DiaryOption entity)
        {
            db.DiaryOptions.Update(entity);
            return entity;
        }
    }
}
