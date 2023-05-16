using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IDeliveryDetailsRepository
    {
        List<DeliveryDetailsModel> GetAllDeliveryDetails();
        Task<List<DeliveryDetailsModel>> GetAllDeliveryDetailsAsync();

        DeliveryDetailsModel GetDeliveryDetailsById(int id);
        Task<DeliveryDetailsModel> GetDeliveryDetailsByIdAsync(int id);

        int AddDeliveryDetails(DeliveryDetailsModel deliveryDetailsModel);
        Task<int> AddDeliveryDetailsAsync(DeliveryDetailsModel deliveryDetailsModel);

        void UpdateDeliveryDetails(int id, DeliveryDetailsModel deliveryDetailsModel);
        Task UpdateDeliveryDetailsAsync(int id, DeliveryDetailsModel deliveryDetailsModel);

        void UpdateDeliveryDetailsPatch(int id, JsonPatchDocument deliveryDetailsModel);
        Task UpdateDeliveryDetailsPatchAsync(int id, JsonPatchDocument deliveryDetailsModel);

        void DeleteDeliveryDetails(int id);
        Task DeleteDeliveryDetailsAsync(int id);
    }
}
