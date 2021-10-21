using Models.BaseModels.CRM;
using Services.Interfaces.CRM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.CRM
{
    public class Gender_Implementation : IGender
    {
        private readonly GarageDreamDbContext db;

        public Gender_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public Gender CreateRecord(Gender entity)
        {
            db.Genders.Add(entity);
            return entity;
        }

        public Gender Delete(Gender entity)
        {
            db.Genders.Remove(entity);
            return entity;
        }

        public IEnumerable<Gender> GenerateDropDowns()
        {
            Gender placeHolder = new Gender
            {
                GenderId = Guid.Empty,
                GenderDescription = "** Please select a gender **"
            };

            List<Gender> result = ReturnAllRecords();
            result.Add(placeHolder);

            return result.OrderBy(x => x.GenderDescription);
        }

        public List<Gender> ReturnAllRecords()
        {
            return db.Genders
                .OrderBy(x => x.GenderDescription)
                .ToList();
        }

        public Gender ReturnSingleRecord(string Description)
        {
            return db.Genders
                .Where(x => x.GenderDescription == Description)
                .FirstOrDefault();
        }

        public Gender ReturnSingleRecord(Guid Id)
        {
            return db.Genders
                .Where(x => x.GenderId == Id)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public Gender UpdateRecord(Gender entity)
        {
            db.Genders.Update(entity);
            return entity;
        }

    }
}
