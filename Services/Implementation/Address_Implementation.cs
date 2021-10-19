using Models.BaseModels.CRM;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation
{
    public class Address_Implementation : IAddress
    {
        private readonly GarageDreamDbContext db;

        public Address_Implementation(GarageDreamDbContext db)
        {
            this.db = db;
        }

        public Address CreateRecord(Address entity)
        {
            db.Addresses.Add(entity);
            return entity;
        }

        public Address Delete(Address entity)
        {
            db.Addresses.Remove(entity);
            return entity;
        }

        public List<Address> ReturnAllRecords()
        {
            return db.Addresses
                .OrderBy(x => x.AddressLine1)
                .ToList();
        }

        public Address ReturnSingleRecord(string Description)
        {
            return db.Addresses
                .Where(x => x.AddressLine1 == Description)
                .FirstOrDefault();
        }

        public Address ReturnSingleRecord(Guid Id)
        {
            return db.Addresses
                .Where(x => x.AddressId == Id)
                .FirstOrDefault();
        }

        public Address ReturnSingleRecordByCustomerId(Guid CustomerId)
        {
            return db.Customers
                .Where(x => x.CustomerId == CustomerId)
                .Select(x => x.Address)
                .FirstOrDefault();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public Address UpdateRecord(Address entity)
        {
            db.Addresses.Update(entity);
            return entity;
        }
    }
}
