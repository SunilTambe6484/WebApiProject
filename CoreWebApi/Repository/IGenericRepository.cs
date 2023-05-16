using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();

        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);

        int Create(TEntity entity);
        Task<int> CreateAsync(TEntity entity);

        void Update(int id, TEntity entity);
        Task UpdateAsync(int id, TEntity entity);

        void UpdatePatch(int id, TEntity entity);
        Task UpdatePatchAsync(int id, TEntity entity);

        void Delete(int id);
        Task DeleteAsync(int id);
    }
}
