using AutoMapper;
using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public class DeliveryAddressRepository : IDeliveryAddressRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public DeliveryAddressRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddDeliveryAddress(DeliveryAddressModel deliveryAddressModel)
        {
            var deliveryAddress = _mapper.Map<DeliveryAddressModel, DeliveryAddress>(deliveryAddressModel);

            _ecommerceDbContext.Add(deliveryAddress);
            _ecommerceDbContext.SaveChanges();

            return deliveryAddress.Id;
        }

        public async Task<int> AddDeliveryAddressAsync(DeliveryAddressModel deliveryAddressModel)
        {
            var deliveryAddress = _mapper.Map<DeliveryAddressModel, DeliveryAddress>(deliveryAddressModel);

            _ecommerceDbContext.Add(deliveryAddress);
            await _ecommerceDbContext.SaveChangesAsync();

            return deliveryAddress.Id;
        }

        public void DeleteDeliveryAddress(int id)
        {
            var deliveryAddress = _ecommerceDbContext.DeliveryAddresses.Find(id);

            _ecommerceDbContext.DeliveryAddresses.Remove(deliveryAddress);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteDeliveryAddressAsync(int id)
        {
            var deliveryAddress = await _ecommerceDbContext.DeliveryAddresses.FindAsync(id);

            _ecommerceDbContext.DeliveryAddresses.Remove(deliveryAddress);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<DeliveryAddressModel> GetAllDeliveryAddresses()
        {
            var deliveryAddressList = _ecommerceDbContext.DeliveryAddresses.ToList();
            return _mapper.Map<List<DeliveryAddressModel>>(deliveryAddressList);
        }

        public async Task<List<DeliveryAddressModel>> GetAllDeliveryAddressesAsync()
        {
            var deliveryAddressList = await _ecommerceDbContext.DeliveryAddresses.ToListAsync();
            return _mapper.Map<List<DeliveryAddressModel>>(deliveryAddressList);
        }

        public DeliveryAddressModel GetDeliveryAddressById(int id)
        {
            var deliveryAddress = _ecommerceDbContext.DeliveryAddresses.Find(id);
            return _mapper.Map<DeliveryAddressModel>(deliveryAddress);
        }

        public async Task<DeliveryAddressModel> GetDeliveryAddressByIdAsync(int id)
        {
            var deliveryAddress = await _ecommerceDbContext.DeliveryAddresses.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<DeliveryAddressModel>(deliveryAddress);
        }

        public void UpdateDeliveryAddress(int id, DeliveryAddressModel deliveryAddressModel)
        {
            var deliveryAddress = _mapper.Map<DeliveryAddressModel, DeliveryAddress>(deliveryAddressModel);
            deliveryAddress.Id = id;

            _ecommerceDbContext.Entry(deliveryAddress).State = EntityState.Modified;
            _ecommerceDbContext.Entry(deliveryAddress).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(deliveryAddress).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateDeliveryAddressAsync(int id, DeliveryAddressModel deliveryAddressModel)
        {
            var deliveryAddress = _mapper.Map<DeliveryAddressModel, DeliveryAddress>(deliveryAddressModel);
            deliveryAddress.Id = id;

            _ecommerceDbContext.Entry(deliveryAddress).State = EntityState.Modified;
            _ecommerceDbContext.Entry(deliveryAddress).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(deliveryAddress).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateDeliveryAddressPatch(int id, JsonPatchDocument deliveryAddressModel)
        {
            var deliveryAddress = _ecommerceDbContext.DeliveryAddresses.Find(id);
            if (deliveryAddress != null)
            {
                deliveryAddressModel.ApplyTo(deliveryAddress);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateDeliveryAddressPatchAsync(int id, JsonPatchDocument deliveryAddressModel)
        {
            var deliveryAddress = await _ecommerceDbContext.DeliveryAddresses.FindAsync(id);
            if (deliveryAddress != null)
            {
                deliveryAddressModel.ApplyTo(deliveryAddress);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
