using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IProductSubTypeRepository
    {
        List<ProductSubTypeModel> GetAllProductSubType();
        Task<List<ProductSubTypeModel>> GetAllProductSubTypeAsync();

        ProductSubTypeModel GetProductSubTypeById(int id);
        Task<ProductSubTypeModel> GetProductSubTypeByIdAsync(int id);

        int AddProductSubType(ProductSubTypeModel productSubTypeModel);
        Task<int> AddProductSubTypeAsync(ProductSubTypeModel productSubTypeModel);

        void UpdateProductSubType(int id, ProductSubTypeModel productSubTypeModel);
        Task UpdateProductSubTypeAsync(int id, ProductSubTypeModel productSubTypeModel);

        void UpdateProductSubTypePatch(int id, JsonPatchDocument productSubTypeModel);
        Task UpdateProductSubTypePatchAsync(int id, JsonPatchDocument productSubTypeModel);

        void DeleteProductSubType(int id);
        Task DeleteProductSubTypeAsync(int id);
    }
}
