using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IProductSpecificationRepository
    {
        List<ProductSpecificationModel> GetAllProductSpecification();
        Task<List<ProductSpecificationModel>> GetAllProductSpecificationAsync();

        ProductSpecificationModel GetProductSpecificationById(int id);
        Task<ProductSpecificationModel> GetProductSpecificationByIdAsync(int id);

        int AddProductSpecification(ProductSpecificationModel productSpecificationModel);
        Task<int> AddProductSpecificationAsync(ProductSpecificationModel productSpecificationModel);

        void UpdateProductSpecification(int id, ProductSpecificationModel productSpecificationModel);
        Task UpdateProductSpecificationAsync(int id, ProductSpecificationModel productSpecificationModel);

        void UpdateProductSpecificationPatch(int id, JsonPatchDocument productSpecificationModel);
        Task UpdateProductSpecificationPatchAsync(int id, JsonPatchDocument productSpecificationModel);

        void DeleteProductSpecification(int id);
        Task DeleteProductSpecificationAsync(int id);
    }
}
