using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface ISubCategoryRepository
    {
        List<SubCategoryModel> GetAllSubCategory();
        Task<List<SubCategoryModel>> GetAllSubCategoryAsync();

        SubCategoryModel GetSubCategoryById(int id);
        Task<SubCategoryModel> GetSubCategoryByIdAsync(int id);

        int AddSubCategory(SubCategoryModel subCategoryModel);
        Task<int> AddSubCategoryAsync(SubCategoryModel subCategoryModel);

        void UpdateSubCategory(int id, SubCategoryModel subCategoryModel);
        Task UpdateSubCategoryAsync(int id, SubCategoryModel subCategoryModel);

        void UpdateSubCategoryPatch(int id, JsonPatchDocument subCategoryModel);
        Task UpdateSubCategoryPatchAsync(int id, JsonPatchDocument subCategoryModel);

        void DeleteSubCategory(int id);
        Task DeleteSubCategoryAsync(int id);
    }
}
