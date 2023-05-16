using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public int Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdatePatch(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePatchAsync(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
