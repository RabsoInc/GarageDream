using Models.BaseModels.CRM;
using Services.Interfaces.CRM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.CRM
{
    public class ContactMethodType_Implementation : IContactMethodType
    {
        private readonly GarageDreamDbContext db;

        public ContactMethodType_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public ContactMethodType CreateRecord(ContactMethodType entity)
        {
            db.ContactMethodTypes.Add(entity);
            return entity;
        }

        public ContactMethodType Delete(ContactMethodType entity)
        {
            db.ContactMethodTypes.Remove(entity);
            return entity;
        }

        public IEnumerable<ContactMethodType> GenerateDropDowns()
        {
            ContactMethodType placeHolder = new ContactMethodType
            {
                ContactMethodTypeId = Guid.Empty,
                ContactMethodTypeDescription = "** Please select a contact method **"
            };

            List<ContactMethodType> result = ReturnAllRecords();
            result.Add(placeHolder);

            return result.OrderBy(x => x.ContactMethodTypeDescription);
        }

        public List<ContactMethodType> ReturnAllRecords()
        {
            return db.ContactMethodTypes
                .OrderBy(x => x.ContactMethodTypeDescription)
                .ToList();
        }

        public ContactMethodType ReturnSingleRecord(string Description)
        {
            return db.ContactMethodTypes
                .Where(x => x.ContactMethodTypeDescription == Description)
                .FirstOrDefault();
        }

        public ContactMethodType ReturnSingleRecord(Guid Id)
        {
            return db.ContactMethodTypes
                .Where(x => x.ContactMethodTypeId == Id)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public ContactMethodType UpdateRecord(ContactMethodType entity)
        {
            db.ContactMethodTypes.Update(entity);
            return entity;
        }
    }
}
