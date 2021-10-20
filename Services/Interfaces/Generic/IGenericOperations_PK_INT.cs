using System.Collections.Generic;

namespace Services.Interfaces.Generic
{
    public interface IGenericOperations_PK_INT<T>
    {
        public List<T> ReturnAllRecords();
        public T ReturnSingleRecord(string Description);
        public T ReturnSingleRecord(int Id);
        public T CreateRecord(T entity);
        public T UpdateRecord(T entity);
        public T Delete(T entity);
        public int SaveChanges();
    }
}
