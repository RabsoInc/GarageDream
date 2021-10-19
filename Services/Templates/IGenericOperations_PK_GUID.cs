using System;
using System.Collections.Generic;

namespace Services.Templates
{
    public interface IGenericOperations_PK_GUID<T>
    {
        public List<T> ReturnAllRecords();
        public T ReturnSingleRecord(string Description);
        public T ReturnSingleRecord(Guid Id);
        public T CreateRecord(T entity);
        public T UpdateRecord(T entity);
        public T Delete(T entity);
        public int SaveChanges();
    }
}
