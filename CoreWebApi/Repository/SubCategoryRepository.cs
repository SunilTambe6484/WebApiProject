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
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public SubCategoryRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddSubCategory(SubCategoryModel subCategoryModel)
        {
            var subCategory = _mapper.Map<SubCategoryModel, SubCategory>(subCategoryModel);

            _ecommerceDbContext.Add(subCategory);
            _ecommerceDbContext.SaveChanges();

            return subCategory.Id;
        }

        public async Task<int> AddSubCategoryAsync(SubCategoryModel subCategoryModel)
        {
            var subCategory = _mapper.Map<SubCategoryModel, SubCategory>(subCategoryModel);

            _ecommerceDbContext.Add(subCategory);
            await _ecommerceDbContext.SaveChangesAsync();

            return subCategory.Id;
        }

        public void DeleteSubCategory(int id)
        {
            var subCategory = _ecommerceDbContext.SubCategories.Find(id);

            _ecommerceDbContext.SubCategories.Remove(subCategory);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteSubCategoryAsync(int id)
        {
            var subCategory = await _ecommerceDbContext.SubCategories.FindAsync(id);

            _ecommerceDbContext.SubCategories.Remove(subCategory);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<SubCategoryModel> GetAllSubCategory()
        {
            var subCategoryList = _ecommerceDbContext.SubCategories.ToList();
            return _mapper.Map<List<SubCategoryModel>>(subCategoryList);
        }

        public async Task<List<SubCategoryModel>> GetAllSubCategoryAsync()
        {
            var subCategoryList = await _ecommerceDbContext.SubCategories.ToListAsync();
            return _mapper.Map<List<SubCategoryModel>>(subCategoryList);
        }

        public SubCategoryModel GetSubCategoryById(int id)
        {
            var subCategory = _ecommerceDbContext.SubCategories.Find(id);
            return _mapper.Map<SubCategoryModel>(subCategory);
        }

        public async Task<SubCategoryModel> GetSubCategoryByIdAsync(int id)
        {
            var SubCategory = await _ecommerceDbContext.SubCategories.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<SubCategoryModel>(SubCategory);
        }

        public void UpdateSubCategory(int id, SubCategoryModel subCategoryModel)
        {
            var SubCategory = _mapper.Map<SubCategoryModel, SubCategory>(subCategoryModel);
            SubCategory.Id = id;

            _ecommerceDbContext.Entry(SubCategory).State = EntityState.Modified;
            _ecommerceDbContext.Entry(SubCategory).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(SubCategory).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateSubCategoryAsync(int id, SubCategoryModel subCategoryModel)
        {
            var SubCategory = _mapper.Map<SubCategoryModel, SubCategory>(subCategoryModel);
            SubCategory.Id = id;

            _ecommerceDbContext.Entry(SubCategory).State = EntityState.Modified;
            _ecommerceDbContext.Entry(SubCategory).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(SubCategory).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateSubCategoryPatch(int id, JsonPatchDocument subCategoryModel)
        {
            var SubCategory = _ecommerceDbContext.SubCategories.Find(id);
            if (SubCategory != null)
            {
                subCategoryModel.ApplyTo(SubCategory);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateSubCategoryPatchAsync(int id, JsonPatchDocument subCategoryModel)
        {
            var SubCategory = await _ecommerceDbContext.SubCategories.FindAsync(id);
            if (SubCategory != null)
            {
                subCategoryModel.ApplyTo(SubCategory);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
