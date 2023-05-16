using CoreWebApi.DL;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IAddressTypeRepository
    {
        List<AddressTypeModel> GetAllAddressTypes();
        Task<List<AddressTypeModel>> GetAllAddressTypesAsync();

        AddressTypeModel GetAddressTypeById(int id);
        Task<AddressTypeModel> GetAddressTypeByIdAsync(int id);

        int AddAddressType(AddressTypeModel addressType);
        Task<int> AddAddressTypeAsync(AddressTypeModel addressType);

        void UpdateAddressType(int id, AddressTypeModel addressType);
        Task UpdateAddressTypeAsync(int id, AddressTypeModel addressType);

        void UpdateAddressTypePatch(int id, JsonPatchDocument addressType);
        Task UpdateAddressTypePatchAsync(int id, JsonPatchDocument addressType);

        void DeleteAddressType(int id);
        Task DeleteAddressTypeAsync(int id);
    }
}
