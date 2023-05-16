using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IProductImagesRepository
    {
        List<ProductImagesModel> GetAllProductImages();
        Task<List<ProductImagesModel>> GetAllProductImagesAsync();

        ProductImagesModel GetProductImagesById(int id);
        Task<ProductImagesModel> GetProductImagesByIdAsync(int id);

        int AddProductImages(ProductImagesModel productImagesModel);
        Task<int> AddProductImagesAsync(ProductImagesModel productImagesModel);

        void UpdateProductImages(int id, ProductImagesModel productImagesModel);
        Task UpdateProductImagesAsync(int id, ProductImagesModel productImagesModel);

        void UpdateProductImagesPatch(int id, JsonPatchDocument productImagesModel);
        Task UpdateProductImagesPatchAsync(int id, JsonPatchDocument productImagesModel);

        void DeleteProductImages(int id);
        Task DeleteProductImagesAsync(int id);
    }
}
