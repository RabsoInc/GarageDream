using Microsoft.EntityFrameworkCore;
using Models.BaseModels.CRM;
using Services.Interfaces.CRM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation.CRM
{
    public class Customer_Implementation : ICustomer
    {
        private readonly GarageDreamDbContext db;

        public Customer_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public Customer CreateRecord(Customer entity)
        {
            db.Customers.Add(entity);
            return entity;
        }

        public Customer Delete(Customer entity)
        {
            db.Customers.Remove(entity);
            return entity;
        }

        public List<Customer> ReturnAllRecords()
        {
            return db.Customers
                .Include(x => x.Title)
                .Include(x => x.Gender)
                .Include(x => x.Address)
                .OrderBy(x => x.LastName)
                .OrderBy(x => x.FirstName)
                .ToList();
        }

        public Customer ReturnSingleRecord(string Description)
        {
            return db.Customers
                .Where(x => x.LastName == Description)
                .Include(x => x.Title)
                .Include(x => x.Gender)
                .Include(x => x.Address)
                .FirstOrDefault();
        }

        public Customer ReturnSingleRecord(Guid Id)
        {
            return db.Customers
                .Where(x => x.CustomerId == Id)
                .Include(x => x.Title)
                .Include(x => x.Gender)
                .Include(x => x.Address)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public Customer UpdateRecord(Customer entity)
        {
            db.Customers.Update(entity);
            return entity;
        }
    }
}
