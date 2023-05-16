using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface ICategoryRepository
    {
        List<CategoryModel> GetAllCategories();
        Task<List<CategoryModel>> GetAllCategoriesAsync();

        CategoryModel GetCategoryById(int id);
        Task<CategoryModel> GetCategoryByIdAsync(int id);

        int AddCategory(CategoryModel categoryModel);
        Task<int> AddCategoryAsync(CategoryModel categoryModel);

        void UpdateCategory(int id, CategoryModel categoryModel);
        Task UpdateCategoryAsync(int id, CategoryModel categoryModel);

        void UpdateCategoryPatch(int id, JsonPatchDocument categoryModel);
        Task UpdateCategoryPatchAsync(int id, JsonPatchDocument categoryModel);

        void DeleteCategory(int id);
        Task DeleteCategoryAsync(int id);
    }
}
