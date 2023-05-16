using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface ISubCategoryProductMapperRepository
    {
        List<SubCategoryProductMapperModel> GetAllSubCategoryProductMappers();
        Task<List<SubCategoryProductMapperModel>> GetAllSubCategoryProductMappersAsync();

        SubCategoryProductMapperModel GetSubCategoryProductMapperById(int id);
        Task<SubCategoryProductMapperModel> GetSubCategoryProductMapperByIdAsync(int id);

        int AddSubCategoryProductMapper(SubCategoryProductMapperModel SubCategoryProductMapper);
        Task<int> AddSubCategoryProductMapperAsync(SubCategoryProductMapperModel SubCategoryProductMapper);

        void UpdateSubCategoryProductMapper(int id, SubCategoryProductMapperModel SubCategoryProductMapper);
        Task UpdateSubCategoryProductMapperAsync(int id, SubCategoryProductMapperModel SubCategoryProductMapper);

        void UpdateSubCategoryProductMapperPatch(int id, JsonPatchDocument SubCategoryProductMapper);
        Task UpdateSubCategoryProductMapperPatchAsync(int id, JsonPatchDocument SubCategoryProductMapper);

        void DeleteSubCategoryProductMapper(int id);
        Task DeleteSubCategoryProductMapperAsync(int id);
    }
}
