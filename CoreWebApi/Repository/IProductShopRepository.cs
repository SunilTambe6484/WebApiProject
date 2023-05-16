using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IProductShopRepository
    {
        List<ProductShopModel> GetAllProductShops();
        Task<List<ProductShopModel>> GetAllProductShopsAsync();

        ProductShopModel GetProductShopById(int id);
        Task<ProductShopModel> GetProductShopByIdAsync(int id);

        int AddProductShop(ProductShopModel productShopModel);
        Task<int> AddProductShopAsync(ProductShopModel productShopModel);

        void UpdateProductShop(int id, ProductShopModel productShopModel);
        Task UpdateProductShopAsync(int id, ProductShopModel productShopModel);

        void UpdateProductShopPatch(int id, JsonPatchDocument productShopModel);
        Task UpdateProductShopPatchAsync(int id, JsonPatchDocument productShopModel);

        void DeleteProductShop(int id);
        Task DeleteProductShopAsync(int id);
    }
}
