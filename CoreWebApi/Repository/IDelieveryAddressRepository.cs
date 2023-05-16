using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IDeliveryAddressRepository
    {
        List<DeliveryAddressModel> GetAllDeliveryAddresses();
        Task<List<DeliveryAddressModel>> GetAllDeliveryAddressesAsync();

        DeliveryAddressModel GetDeliveryAddressById(int id);
        Task<DeliveryAddressModel> GetDeliveryAddressByIdAsync(int id);

        int AddDeliveryAddress(DeliveryAddressModel deliveryAddressModel);
        Task<int> AddDeliveryAddressAsync(DeliveryAddressModel deliveryAddressModel);

        void UpdateDeliveryAddress(int id, DeliveryAddressModel deliveryAddressModel);
        Task UpdateDeliveryAddressAsync(int id, DeliveryAddressModel deliveryAddressModel);

        void UpdateDeliveryAddressPatch(int id, JsonPatchDocument deliveryAddressModel);
        Task UpdateDeliveryAddressPatchAsync(int id, JsonPatchDocument deliveryAddressModel);

        void DeleteDeliveryAddress(int id);
        Task DeleteDeliveryAddressAsync(int id);
    }
}
