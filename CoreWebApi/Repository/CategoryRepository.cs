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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public CategoryRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddCategory(CategoryModel categoryModel)
        {
            var category = _mapper.Map<CategoryModel, Category>(categoryModel);

            _ecommerceDbContext.Add(category);
            _ecommerceDbContext.SaveChanges();

            return category.Id;
        }

        public async Task<int> AddCategoryAsync(CategoryModel categoryModel)
        {
            var category = _mapper.Map<CategoryModel, Category>(categoryModel);

            _ecommerceDbContext.Add(category);
            await _ecommerceDbContext.SaveChangesAsync();

            return category.Id;
        }

        public void DeleteCategory(int id)
        {
            var category = _ecommerceDbContext.Categories.Find(id);

            _ecommerceDbContext.Categories.Remove(category);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _ecommerceDbContext.Categories.FindAsync(id);

            _ecommerceDbContext.Categories.Remove(category);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<CategoryModel> GetAllCategories()
        {
            var categoryList = _ecommerceDbContext.Categories.ToList();
            return _mapper.Map<List<CategoryModel>>(categoryList);
        }

        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            var categoryList = await _ecommerceDbContext.Categories.ToListAsync();
            return _mapper.Map<List<CategoryModel>>(categoryList);
        }

        public CategoryModel GetCategoryById(int id)
        {
            var category = _ecommerceDbContext.Categories.Find(id);
            return _mapper.Map<CategoryModel>(category);
        }

        public async Task<CategoryModel> GetCategoryByIdAsync(int id)
        {
            var category = await _ecommerceDbContext.Categories.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<CategoryModel>(category);
        }

        public void UpdateCategory(int id, CategoryModel categoryModel)
        {
            var category = _mapper.Map<CategoryModel, Category>(categoryModel);
            category.Id = id;

            _ecommerceDbContext.Entry(category).State = EntityState.Modified;
            _ecommerceDbContext.Entry(category).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(category).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateCategoryAsync(int id, CategoryModel categoryModel)
        {
            var category = _mapper.Map<CategoryModel, Category>(categoryModel);
            category.Id = id;

            _ecommerceDbContext.Entry(category).State = EntityState.Modified;
            _ecommerceDbContext.Entry(category).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(category).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateCategoryPatch(int id, JsonPatchDocument categoryModel)
        {
            var category = _ecommerceDbContext.Categories.Find(id);
            if (category != null)
            {
                categoryModel.ApplyTo(category);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateCategoryPatchAsync(int id, JsonPatchDocument categoryModel)
        {
            var category = await _ecommerceDbContext.Categories.FindAsync(id);
            if (category != null)
            {
                categoryModel.ApplyTo(category);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
