using CoreWebApi.DL;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public class ProductSizeRepository : IProductSizeRepository
    {
        public int AddProductSize(ProductSize ProductSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddProductSizeAsync(ProductSize ProductSize)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductSize(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductSizeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductSize> GetAllProductSize()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductSize>> GetAllProductSizeAsync()
        {
            throw new NotImplementedException();
        }

        public ProductSize GetProductSizeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductSize> GetProductSizeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductSize(int id, ProductSize ProductSize)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductSizeAsync(int id, ProductSize ProductSize)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductSizePatch(int id, JsonPatchDocument ProductSize)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductSizePatchAsync(int id, JsonPatchDocument ProductSize)
        {
            throw new NotImplementedException();
        }
    }
}
