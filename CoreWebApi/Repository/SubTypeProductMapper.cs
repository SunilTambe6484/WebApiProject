using AutoMapper;
using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public class SubTypeProductMapperRepository : ISubTypeProductMapperRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public SubTypeProductMapperRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddSubTypeProductMapper(SubTypeProductMapperModel subTypeProductMapperModel)
        {
            var subTypeProductMapper = _mapper.Map<SubTypeProductMapperModel, SubTypeProductMapper>(subTypeProductMapperModel);

            _ecommerceDbContext.Add(subTypeProductMapper);
            _ecommerceDbContext.SaveChanges();

            return subTypeProductMapper.ID;
        }

        public async Task<int> AddSubTypeProductMapperAsync(SubTypeProductMapperModel subTypeProductMapperModel)
        {
            var subTypeProductMapper = _mapper.Map<SubTypeProductMapperModel, SubTypeProductMapper>(subTypeProductMapperModel);

            _ecommerceDbContext.Add(subTypeProductMapper);
            await _ecommerceDbContext.SaveChangesAsync();

            return subTypeProductMapper.ID;
        }

        public void DeleteSubTypeProductMapper(int id)
        {
            var subTypeProductMapper = _ecommerceDbContext.SubTypeProductMappers.Find(id);

            _ecommerceDbContext.SubTypeProductMappers.Remove(subTypeProductMapper);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteSubTypeProductMapperAsync(int id)
        {
            var subTypeProductMapper = await _ecommerceDbContext.SubTypeProductMappers.FindAsync(id);

            _ecommerceDbContext.SubTypeProductMappers.Remove(subTypeProductMapper);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<SubTypeProductMapperModel> GetAllSubTypeProductMapper()
        {
            var subTypeProductMapperList = _ecommerceDbContext.SubTypeProductMappers.ToList();
            return _mapper.Map<List<SubTypeProductMapperModel>>(subTypeProductMapperList);
        }

        public async Task<List<SubTypeProductMapperModel>> GetAllSubTypeProductMapperAsync()
        {
            var subTypeProductMapperList = await _ecommerceDbContext.SubTypeProductMappers.ToListAsync();
            return _mapper.Map<List<SubTypeProductMapperModel>>(subTypeProductMapperList);
        }

        public SubTypeProductMapperModel GetSubTypeProductMapperById(int id)
        {
            var subTypeProductMapper = _ecommerceDbContext.SubTypeProductMappers.Find(id);
            return _mapper.Map<SubTypeProductMapperModel>(subTypeProductMapper);
        }

        public async Task<SubTypeProductMapperModel> GetSubTypeProductMapperByIdAsync(int id)
        {
            var subTypeProductMapper = await _ecommerceDbContext.SubTypeProductMappers.Where(a => a.ID == id).FirstOrDefaultAsync();
            return _mapper.Map<SubTypeProductMapperModel>(subTypeProductMapper);
        }

        public void UpdateSubTypeProductMapper(int id, SubTypeProductMapperModel subTypeProductMapperModel)
        {
            var subTypeProductMapper = _mapper.Map<SubTypeProductMapperModel, SubTypeProductMapper>(subTypeProductMapperModel);
            subTypeProductMapper.ID = id;

            _ecommerceDbContext.Entry(subTypeProductMapper).State = EntityState.Modified;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateSubTypeProductMapperAsync(int id, SubTypeProductMapperModel subTypeProductMapperModel)
        {
            var subTypeProductMapper = _mapper.Map<SubTypeProductMapperModel, SubTypeProductMapper>(subTypeProductMapperModel);
            subTypeProductMapper.ID = id;

            _ecommerceDbContext.Entry(subTypeProductMapper).State = EntityState.Modified;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateSubTypeProductMapperPatch(int id, JsonPatchDocument subTypeProductMapperModel)
        {
            var subTypeProductMapper = _ecommerceDbContext.SubTypeProductMappers.Find(id);
            if (subTypeProductMapper != null)
            {
                subTypeProductMapperModel.ApplyTo(subTypeProductMapper);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateSubTypeProductMapperPatchAsync(int id, JsonPatchDocument subTypeProductMapperModel)
        {
            var subTypeProductMapper = await _ecommerceDbContext.SubTypeProductMappers.FindAsync(id);
            if (subTypeProductMapper != null)
            {
                subTypeProductMapperModel.ApplyTo(subTypeProductMapper);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
