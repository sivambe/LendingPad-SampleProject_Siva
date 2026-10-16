using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IInMemoryRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Add(T entity);
        bool Update(T entity);
        bool Delete(Guid id);

        void DeleteAll();
    }
}
