using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IDeliveryDetailsOrderMapperRepository
    {
        List<DeliveryDetailsOrderMapperModel> GetAllDeliveryDetailsOrderMappers();
        Task<List<DeliveryDetailsOrderMapperModel>> GetAllDeliveryDetailsOrderMappersAsync();

        DeliveryDetailsOrderMapperModel GetDeliveryDetailsOrderMapperById(int id);
        Task<DeliveryDetailsOrderMapperModel> GetDeliveryDetailsOrderMapperByIdAsync(int id);

        int AddDeliveryDetailsOrderMapper(DeliveryDetailsOrderMapperModel deliveryDetailsOrderMapperModel);
        Task<int> AddDeliveryDetailsOrderMapperAsync(DeliveryDetailsOrderMapperModel deliveryDetailsOrderMapperModel);

        void UpdateDeliveryDetailsOrderMapper(int id, DeliveryDetailsOrderMapperModel deliveryDetailsOrderMapperModel);
        Task UpdateDeliveryDetailsOrderMapperAsync(int id, DeliveryDetailsOrderMapperModel deliveryDetailsOrderMapperModel);

        void UpdateDeliveryDetailsOrderMapperPatch(int id, JsonPatchDocument deliveryDetailsOrderMapperModel);
        Task UpdateDeliveryDetailsOrderMapperPatchAsync(int id, JsonPatchDocument deliveryDetailsOrderMapperModel);

        void DeleteDeliveryDetailsOrderMapper(int id);
        Task DeleteDeliveryDetailsOrderMapperAsync(int id);
    }
}
