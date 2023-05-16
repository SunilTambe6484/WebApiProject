using CoreWebApi.DL;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IProductSizeRepository
    {
        List<ProductSize> GetAllProductSize();
        Task<List<ProductSize>> GetAllProductSizeAsync();

        ProductSize GetProductSizeById(int id);
        Task<ProductSize> GetProductSizeByIdAsync(int id);

        int AddProductSize(ProductSize ProductSize);
        Task<int> AddProductSizeAsync(ProductSize ProductSize);

        void UpdateProductSize(int id, ProductSize ProductSize);
        Task UpdateProductSizeAsync(int id, ProductSize ProductSize);

        void UpdateProductSizePatch(int id, JsonPatchDocument ProductSize);
        Task UpdateProductSizePatchAsync(int id, JsonPatchDocument ProductSize);

        void DeleteProductSize(int id);
        Task DeleteProductSizeAsync(int id);
    }
}
