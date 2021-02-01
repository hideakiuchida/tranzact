using System.Collections.Generic;

namespace SearchFight.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(object query);
        List<T> GetAll(int id);
        void SaveChanges();
    }
}
