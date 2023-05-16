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
    public class SubCategoryProductMapperRepository : ISubCategoryProductMapperRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public SubCategoryProductMapperRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddSubCategoryProductMapper(SubCategoryProductMapperModel subCategoryProductMapperModel)
        {
            var subCategoryProductMapper = _mapper.Map<SubCategoryProductMapperModel, SubCategoryProductMapper>(subCategoryProductMapperModel);

            _ecommerceDbContext.Add(subCategoryProductMapper);
            _ecommerceDbContext.SaveChanges();

            return subCategoryProductMapper.Id;
        }

        public async Task<int> AddSubCategoryProductMapperAsync(SubCategoryProductMapperModel subCategoryProductMapperModel)
        {
            var subCategoryProductMapper = _mapper.Map<SubCategoryProductMapperModel, SubCategoryProductMapper>(subCategoryProductMapperModel);

            _ecommerceDbContext.Add(subCategoryProductMapper);
            await _ecommerceDbContext.SaveChangesAsync();

            return subCategoryProductMapper.Id;
        }

        public void DeleteSubCategoryProductMapper(int id)
        {
            var subCategoryProductMapper = _ecommerceDbContext.SubCategoryProductMappers.Find(id);

            _ecommerceDbContext.SubCategoryProductMappers.Remove(subCategoryProductMapper);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteSubCategoryProductMapperAsync(int id)
        {
            var subCategoryProductMapper = await _ecommerceDbContext.SubCategoryProductMappers.FindAsync(id);

            _ecommerceDbContext.SubCategoryProductMappers.Remove(subCategoryProductMapper);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<SubCategoryProductMapperModel> GetAllSubCategoryProductMappers()
        {
            var subCategoryProductMapperList = _ecommerceDbContext.SubCategoryProductMappers.ToList();
            return _mapper.Map<List<SubCategoryProductMapperModel>>(subCategoryProductMapperList);
        }

        public async Task<List<SubCategoryProductMapperModel>> GetAllSubCategoryProductMappersAsync()
        {
            var subCategoryProductMapperList = await _ecommerceDbContext.SubCategoryProductMappers.ToListAsync();
            return _mapper.Map<List<SubCategoryProductMapperModel>>(subCategoryProductMapperList);
        }

        public SubCategoryProductMapperModel GetSubCategoryProductMapperById(int id)
        {
            var subCategoryProductMapper = _ecommerceDbContext.SubCategoryProductMappers.Find(id);
            return _mapper.Map<SubCategoryProductMapperModel>(subCategoryProductMapper);
        }

        public async Task<SubCategoryProductMapperModel> GetSubCategoryProductMapperByIdAsync(int id)
        {
            var subCategoryProductMapper = await _ecommerceDbContext.SubCategoryProductMappers.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<SubCategoryProductMapperModel>(subCategoryProductMapper);
        }

        public void UpdateSubCategoryProductMapper(int id, SubCategoryProductMapperModel subCategoryProductMapperModel)
        {
            var subCategoryProductMapper = _mapper.Map<SubCategoryProductMapperModel, SubCategoryProductMapper>(subCategoryProductMapperModel);
            subCategoryProductMapper.Id = id;

            _ecommerceDbContext.Entry(subCategoryProductMapper).State = EntityState.Modified;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateSubCategoryProductMapperAsync(int id, SubCategoryProductMapperModel subCategoryProductMapperModel)
        {
            var subCategoryProductMapper = _mapper.Map<SubCategoryProductMapperModel, SubCategoryProductMapper>(subCategoryProductMapperModel);
            subCategoryProductMapper.Id = id;

            _ecommerceDbContext.Entry(subCategoryProductMapper).State = EntityState.Modified;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateSubCategoryProductMapperPatch(int id, JsonPatchDocument SubCategoryProductMapper)
        {
            var subCategoryProductMapper = _ecommerceDbContext.SubCategoryProductMappers.Find(id);
            if (subCategoryProductMapper != null)
            {
                SubCategoryProductMapper.ApplyTo(subCategoryProductMapper);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateSubCategoryProductMapperPatchAsync(int id, JsonPatchDocument SubCategoryProductMapper)
        {
            var subCategoryProductMapper = await _ecommerceDbContext.SubCategoryProductMappers.FindAsync(id);
            if (subCategoryProductMapper != null)
            {
                SubCategoryProductMapper.ApplyTo(subCategoryProductMapper);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
