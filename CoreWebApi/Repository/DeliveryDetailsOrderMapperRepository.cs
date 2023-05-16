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
    public class DeliveryDetailsOrderMapperRepository : IDeliveryDetailsOrderMapperRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public DeliveryDetailsOrderMapperRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddDeliveryDetailsOrderMapper(DeliveryDetailsOrderMapperModel deliveryDetailsOrderMapperModel)
        {
            var deliveryDetailsOrderMapper = _mapper.Map<DeliveryDetailsOrderMapperModel, DeliveryDetailsOrderMapper>(deliveryDetailsOrderMapperModel);

            _ecommerceDbContext.Add(deliveryDetailsOrderMapper);
            _ecommerceDbContext.SaveChanges();

            return deliveryDetailsOrderMapper.Id;
        }

        public async Task<int> AddDeliveryDetailsOrderMapperAsync(DeliveryDetailsOrderMapperModel deliveryDetailsOrderMapperModel)
        {
            var deliveryDetailsOrderMapper = _mapper.Map<DeliveryDetailsOrderMapperModel, DeliveryDetailsOrderMapper>(deliveryDetailsOrderMapperModel);

            _ecommerceDbContext.Add(deliveryDetailsOrderMapper);
            await _ecommerceDbContext.SaveChangesAsync();

            return deliveryDetailsOrderMapper.Id;
        }

        public void DeleteDeliveryDetailsOrderMapper(int id)
        {
            var deliveryDetailsOrderMapper = _ecommerceDbContext.DeliveryDetailsOrderMappers.Find(id);

            _ecommerceDbContext.DeliveryDetailsOrderMappers.Remove(deliveryDetailsOrderMapper);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteDeliveryDetailsOrderMapperAsync(int id)
        {
            var deliveryDetailsOrderMapper = await _ecommerceDbContext.DeliveryDetailsOrderMappers.FindAsync(id);

            _ecommerceDbContext.DeliveryDetailsOrderMappers.Remove(deliveryDetailsOrderMapper);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<DeliveryDetailsOrderMapperModel> GetAllDeliveryDetailsOrderMappers()
        {
            var deliveryDetailsOrderMapperList = _ecommerceDbContext.DeliveryDetailsOrderMappers.ToList();
            return _mapper.Map<List<DeliveryDetailsOrderMapperModel>>(deliveryDetailsOrderMapperList);
        }

        public async Task<List<DeliveryDetailsOrderMapperModel>> GetAllDeliveryDetailsOrderMappersAsync()
        {
            var deliveryDetailsOrderMapperList = await _ecommerceDbContext.DeliveryDetailsOrderMappers.ToListAsync();
            return _mapper.Map<List<DeliveryDetailsOrderMapperModel>>(deliveryDetailsOrderMapperList);
        }

        public DeliveryDetailsOrderMapperModel GetDeliveryDetailsOrderMapperById(int id)
        {
            var deliveryDetailsOrderMapper = _ecommerceDbContext.DeliveryDetailsOrderMappers.Find(id);
            return _mapper.Map<DeliveryDetailsOrderMapperModel>(deliveryDetailsOrderMapper);
        }

        public async Task<DeliveryDetailsOrderMapperModel> GetDeliveryDetailsOrderMapperByIdAsync(int id)
        {
            var deliveryDetailsOrderMapper = await _ecommerceDbContext.DeliveryDetailsOrderMappers.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<DeliveryDetailsOrderMapperModel>(deliveryDetailsOrderMapper);
        }

        public void UpdateDeliveryDetailsOrderMapper(int id, DeliveryDetailsOrderMapperModel deliveryDetailsOrderMapperModel)
        {
            var deliveryDetailsOrderMapper = _mapper.Map<DeliveryDetailsOrderMapperModel, DeliveryDetailsOrderMapper>(deliveryDetailsOrderMapperModel);
            deliveryDetailsOrderMapper.Id = id;

            _ecommerceDbContext.Entry(deliveryDetailsOrderMapper).State = EntityState.Modified;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateDeliveryDetailsOrderMapperAsync(int id, DeliveryDetailsOrderMapperModel deliveryDetailsOrderMapperModel)
        {
            var deliveryDetailsOrderMapper = _mapper.Map<DeliveryDetailsOrderMapperModel, DeliveryDetailsOrderMapper>(deliveryDetailsOrderMapperModel);
            deliveryDetailsOrderMapper.Id = id;

            _ecommerceDbContext.Entry(deliveryDetailsOrderMapper).State = EntityState.Modified;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateDeliveryDetailsOrderMapperPatch(int id, JsonPatchDocument deliveryDetailsOrderMapperModel)
        {
            var deliveryDetailsOrderMapper = _ecommerceDbContext.DeliveryDetailsOrderMappers.Find(id);
            if (deliveryDetailsOrderMapper != null)
            {
                deliveryDetailsOrderMapperModel.ApplyTo(deliveryDetailsOrderMapper);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateDeliveryDetailsOrderMapperPatchAsync(int id, JsonPatchDocument deliveryDetailsOrderMapperModel)
        {
            var deliveryDetailsOrderMapper = await _ecommerceDbContext.DeliveryDetailsOrderMappers.FindAsync(id);
            if (deliveryDetailsOrderMapper != null)
            {
                deliveryDetailsOrderMapperModel.ApplyTo(deliveryDetailsOrderMapper);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
