using Models.BaseModels.CRM;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class Title_Implementation : ITitle
    {
        private readonly GarageDreamDbContext db;

        public Title_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public Title CreateRecord(Title entity)
        {
            db.Titles.Add(entity);
            return entity;
        }

        public Title Delete(Title entity)
        {
            db.Titles.Remove(entity);
            return entity;
        }

        public List<Title> ReturnAllRecords()
        {
            return db.Titles
                .OrderBy(x => x.TitleDescription)
                .ToList();
        }

        public Title ReturnSingleRecord(string Description)
        {
            return db.Titles
                .Where(x => x.TitleDescription == Description)
                .FirstOrDefault();
        }

        public Title ReturnSingleRecord(Guid Id)
        {
            return db.Titles
                .Where(x => x.TitleId == Id)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public Title UpdateRecord(Title entity)
        {
            db.Titles.Update(entity);
            return entity;
        }

        public IEnumerable<Title> GenerateDropDowns()
        {
            Title placeHolder = new Title
            {
                TitleId = Guid.Empty,
                TitleDescription = "** Please select a title **"
            };

            List<Title> result = ReturnAllRecords();
            result.Add(placeHolder);

            return result.OrderBy(x => x.TitleDescription);
        }
    }
}
