using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IProductTypeRepository
    {
        List<ProductTypeModel> GetAllProductType();
        Task<List<ProductTypeModel>> GetAllProductTypeAsync();

        ProductTypeModel GetProductTypeById(int id);
        Task<ProductTypeModel> GetProductTypeByIdAsync(int id);

        int AddProductType(ProductTypeModel productTypeModel);
        Task<int> AddProductTypeAsync(ProductTypeModel productTypeModel);

        void UpdateProductType(int id, ProductTypeModel productTypeModel);
        Task UpdateProductTypeAsync(int id, ProductTypeModel productTypeModel);

        void UpdateProductTypePatch(int id, JsonPatchDocument productTypeModel);
        Task UpdateProductTypePatchAsync(int id, JsonPatchDocument productTypeModel);

        void DeleteProductType(int id);
        Task DeleteProductTypeAsync(int id);
    }
}
