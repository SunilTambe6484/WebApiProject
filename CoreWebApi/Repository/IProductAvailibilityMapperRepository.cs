using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IProductAvailibilityMapperRepository
    {
        List<ProductAvailibilityMapperModel> GetAllProductAvailibilityMapper();
        Task<List<ProductAvailibilityMapperModel>> GetAllProductAvailibilityMapperAsync();

        ProductAvailibilityMapperModel GetProductAvailibilityMapperById(int id);
        Task<ProductAvailibilityMapperModel> GetProductAvailibilityMapperByIdAsync(int id);

        int AddProductAvailibilityMapper(ProductAvailibilityMapperModel productAvailibilityMapperModel);
        Task<int> AddProductAvailibilityMapperAsync(ProductAvailibilityMapperModel productAvailibilityMapperModel);

        void UpdateProductAvailibilityMapper(int id, ProductAvailibilityMapperModel productAvailibilityMapperModel);
        Task UpdateProductAvailibilityMapperAsync(int id, ProductAvailibilityMapperModel productAvailibilityMapperModel);

        void UpdateProductAvailibilityMapperPatch(int id, JsonPatchDocument productAvailibilityMapperModel);
        Task UpdateProductAvailibilityMapperPatchAsync(int id, JsonPatchDocument productAvailibilityMapperModel);

        void DeleteProductAvailibilityMapper(int id);
        Task DeleteProductAvailibilityMapperAsync(int id);
    }
}
