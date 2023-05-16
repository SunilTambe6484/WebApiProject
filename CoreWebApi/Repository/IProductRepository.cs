using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IProductRepository
    {
        List<ProductModel> GetAllProducts();
        Task<List<ProductModel>> GetAllProductsAsync();

        ProductModel GetProductById(int id);
        Task<ProductModel> GetProductByIdAsync(int id);

        int AddProduct(ProductModel productModel);
        Task<int> AddProductAsync(ProductModel productModel);

        void UpdateProduct(int id, ProductModel productModel);
        Task UpdateProductAsync(int id, ProductModel productModel);

        void UpdateProductPatch(int id, JsonPatchDocument productModel);
        Task UpdateProductPatchAsync(int id, JsonPatchDocument productModel);

        void DeleteProduct(int id);
        Task DeleteProductAsync(int id);
    }
}
