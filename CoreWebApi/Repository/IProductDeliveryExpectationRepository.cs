using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IProductDeliveryExpectationRepository
    {
        List<ProductDeliveryExpectationModel> GetAllProductDeliveryExpectation();
        Task<List<ProductDeliveryExpectationModel>> GetAllProductDeliveryExpectationAsync();

        ProductDeliveryExpectationModel GetProductDeliveryExpectationById(int id);
        Task<ProductDeliveryExpectationModel> GetProductDeliveryExpectationByIdAsync(int id);

        int AddProductDeliveryExpectation(ProductDeliveryExpectationModel productDeliveryExpectationModel);
        Task<int> AddProductDeliveryExpectationAsync(ProductDeliveryExpectationModel productDeliveryExpectationModel);

        void UpdateProductDeliveryExpectation(int id, ProductDeliveryExpectationModel productDeliveryExpectationModel);
        Task UpdateProductDeliveryExpectationAsync(int id, ProductDeliveryExpectationModel productDeliveryExpectationModel);

        void UpdateProductDeliveryExpectationPatch(int id, JsonPatchDocument productDeliveryExpectationModel);
        Task UpdateProductDeliveryExpectationPatchAsync(int id, JsonPatchDocument productDeliveryExpectationModel);

        void DeleteProductDeliveryExpectation(int id);
        Task DeleteProductDeliveryExpectationAsync(int id);
    }
}
