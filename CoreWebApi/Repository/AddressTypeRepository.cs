using AutoMapper;
using CoreWebApi.DL;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public class AddressTypeRepository : IAddressTypeRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public AddressTypeRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddAddressType(AddressTypeModel addressTypeModel)
        {
            var addressType = _mapper.Map<AddressTypeModel, AddressType>(addressTypeModel);

            _ecommerceDbContext.Add(addressType);
            _ecommerceDbContext.SaveChanges();

            return addressType.Id;
        }

        public async Task<int> AddAddressTypeAsync(AddressTypeModel addressTypeModel)
        {
            var addressType = _mapper.Map<AddressTypeModel, AddressType>(addressTypeModel);

            _ecommerceDbContext.Add(addressType);
            await _ecommerceDbContext.SaveChangesAsync();

            return addressType.Id;
        }

        public void DeleteAddressType(int id)
        {
            var addressType = _ecommerceDbContext.AddressTypes.Find(id);

            _ecommerceDbContext.AddressTypes.Remove(addressType);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteAddressTypeAsync(int id)
        {
            var addressType = await _ecommerceDbContext.AddressTypes.FindAsync(id);

            _ecommerceDbContext.AddressTypes.Remove(addressType);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public AddressTypeModel GetAddressTypeById(int id)
        {
            var addressType = _ecommerceDbContext.AddressTypes.Find(id);
            return _mapper.Map<AddressTypeModel>(addressType);
        }

        public async Task<AddressTypeModel> GetAddressTypeByIdAsync(int id)
        {
            var country = await _ecommerceDbContext.AddressTypes.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<AddressTypeModel>(country);
        }

        public List<AddressTypeModel> GetAllAddressTypes()
        {
            var addressTypeList = _ecommerceDbContext.AddressTypes.ToList();
            return _mapper.Map<List<AddressTypeModel>>(addressTypeList);
        }

        public async Task<List<AddressTypeModel>> GetAllAddressTypesAsync()
        {
            var addressTypeList = await _ecommerceDbContext.AddressTypes.ToListAsync();
            return _mapper.Map<List<AddressTypeModel>>(addressTypeList);
        }

        public void UpdateAddressType(int id, AddressTypeModel addressTypeModel)
        {
            var addressType = _mapper.Map<AddressTypeModel, AddressType>(addressTypeModel);
            addressType.Id = id;

            _ecommerceDbContext.Entry(addressType).State = EntityState.Modified;
            _ecommerceDbContext.Entry(addressType).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(addressType).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateAddressTypeAsync(int id, AddressTypeModel addressTypeModel)
        {
            var adressType = _mapper.Map<AddressTypeModel, AddressType>(addressTypeModel);
            adressType.Id = id;
            //_ecommerceDbContext.Countries.Update(country);
            _ecommerceDbContext.Entry(adressType).State = EntityState.Modified;
            _ecommerceDbContext.Entry(adressType).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(adressType).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateAddressTypePatch(int id, JsonPatchDocument addressTypeModel)
        {
            var addressType = _ecommerceDbContext.AddressTypes.Find(id);
            if (addressType != null)
            {
                addressTypeModel.ApplyTo(addressType);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateAddressTypePatchAsync(int id, JsonPatchDocument addressTypeModel)
        {
            var addressType = await _ecommerceDbContext.AddressTypes.FindAsync(id);
            if (addressType != null)
            {
                addressTypeModel.ApplyTo(addressType);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
