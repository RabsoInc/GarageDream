using Microsoft.EntityFrameworkCore;
using Models.BaseModels.CRM;
using Services.Interfaces.CRM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.CRM
{
    public class CustomerContactDetail_Implementation : ICustomerContactDetail
    {
        private readonly GarageDreamDbContext db;

        public CustomerContactDetail_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public CustomerContactDetail CreateRecord(CustomerContactDetail entity)
        {
            db.CustomerContactDetails.Add(entity);
            return entity;
        }

        public CustomerContactDetail Delete(CustomerContactDetail entity)
        {
            db.CustomerContactDetails.Remove(entity);
            return entity;
        }

        public List<CustomerContactDetail> ReturnAllRecords()
        {
            return db.CustomerContactDetails
                .Include(x => x.ContactMethodType)
                .ToList();
        }

        public List<CustomerContactDetail> ReturnAllRecords(Guid CustomerId)
        {
            return db.CustomerContactDetails
                .Where(x => x.Customer.CustomerId == CustomerId)
                .Include(x => x.ContactMethodType)
                .ToList();
        }

        public CustomerContactDetail ReturnSingleRecord(string Description)
        {
            return db.CustomerContactDetails
                .Where(x => x.Comments == Description)
                .FirstOrDefault();
        }

        public CustomerContactDetail ReturnSingleRecord(Guid Id)
        {
            return db.CustomerContactDetails
                .Where(x => x.CustomerContactDetailId == Id)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public CustomerContactDetail UpdateRecord(CustomerContactDetail entity)
        {
            db.CustomerContactDetails.Update(entity);
            return entity;
        }
    }
}
