using BusinessEntities;
using Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class InMemoryRepository<T> : IInMemoryRepository<T> where T : IdObject
    {
        protected readonly Dictionary<Guid, T> _storage = new Dictionary<Guid, T>();

        public IEnumerable<T> GetAll() => _storage.Values;

        public T GetById(Guid id)
        {
            _storage.TryGetValue(id, out var entity);
            return entity;
        }


        public void Add(T entity)
        {
            _storage[entity.Id] = entity;
        }

        public bool Update( T entity)
        {
            if (!_storage.ContainsKey(entity.Id)) return false;
            _storage[entity.Id] = entity;
            return true;
        }

        public bool Delete(Guid id)
        {
            if(!_storage.ContainsKey(id)) return false;
            return _storage.Remove(id);

        }

        //Clear all entities from the specific repository
        public void DeleteAll()
        {
            _storage.Clear();
        }
    }
}
