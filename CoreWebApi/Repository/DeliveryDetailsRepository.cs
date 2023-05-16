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
    public class DeliveryDetailsRepository : IDeliveryDetailsRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public DeliveryDetailsRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddDeliveryDetails(DeliveryDetailsModel deliveryDetailsModel)
        {
            var deliveryDetails = _mapper.Map<DeliveryDetailsModel, DeliveryDetails>(deliveryDetailsModel);

            _ecommerceDbContext.Add(deliveryDetails);
            _ecommerceDbContext.SaveChanges();

            return deliveryDetails.Id;
        }

        public async Task<int> AddDeliveryDetailsAsync(DeliveryDetailsModel deliveryDetailsModel)
        {
            var deliveryDetails = _mapper.Map<DeliveryDetailsModel, DeliveryDetails>(deliveryDetailsModel);

            _ecommerceDbContext.Add(deliveryDetails);
            await _ecommerceDbContext.SaveChangesAsync();

            return deliveryDetails.Id;
        }

        public void DeleteDeliveryDetails(int id)
        {
            var deliveryDetails = _ecommerceDbContext.DeliveryDetails.Find(id);

            _ecommerceDbContext.DeliveryDetails.Remove(deliveryDetails);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteDeliveryDetailsAsync(int id)
        {
            var deliveryDetails = await _ecommerceDbContext.DeliveryDetails.FindAsync(id);

            _ecommerceDbContext.DeliveryDetails.Remove(deliveryDetails);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<DeliveryDetailsModel> GetAllDeliveryDetails()
        {
            var deliveryDetailsList = _ecommerceDbContext.DeliveryDetails.ToList();
            return _mapper.Map<List<DeliveryDetailsModel>>(deliveryDetailsList);
        }

        public async Task<List<DeliveryDetailsModel>> GetAllDeliveryDetailsAsync()
        {
            var deliveryDetailsList = await _ecommerceDbContext.DeliveryDetails.ToListAsync();
            return _mapper.Map<List<DeliveryDetailsModel>>(deliveryDetailsList);
        }

        public DeliveryDetailsModel GetDeliveryDetailsById(int id)
        {
            var deliveryDetails = _ecommerceDbContext.DeliveryDetails.Find(id);
            return _mapper.Map<DeliveryDetailsModel>(deliveryDetails);
        }

        public async Task<DeliveryDetailsModel> GetDeliveryDetailsByIdAsync(int id)
        {
            var deliveryDetails = await _ecommerceDbContext.DeliveryDetails.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<DeliveryDetailsModel>(deliveryDetails);
        }

        public void UpdateDeliveryDetails(int id, DeliveryDetailsModel deliveryDetailsModel)
        {
            var deliveryDetails = _mapper.Map<DeliveryDetailsModel, DeliveryDetails>(deliveryDetailsModel);
            deliveryDetails.Id = id;

            _ecommerceDbContext.Entry(deliveryDetails).State = EntityState.Modified;
            _ecommerceDbContext.Entry(deliveryDetails).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(deliveryDetails).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateDeliveryDetailsAsync(int id, DeliveryDetailsModel deliveryDetailsModel)
        {
            var deliveryDetails = _mapper.Map<DeliveryDetailsModel, DeliveryDetails>(deliveryDetailsModel);
            deliveryDetails.Id = id;

            _ecommerceDbContext.Entry(deliveryDetails).State = EntityState.Modified;
            _ecommerceDbContext.Entry(deliveryDetails).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(deliveryDetails).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateDeliveryDetailsPatch(int id, JsonPatchDocument deliveryDetailsModel)
        {
            var deliveryDetails = _ecommerceDbContext.DeliveryDetails.Find(id);
            if (deliveryDetails != null)
            {
                deliveryDetailsModel.ApplyTo(deliveryDetails);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateDeliveryDetailsPatchAsync(int id, JsonPatchDocument deliveryDetailsModel)
        {
            var deliveryDetails = await _ecommerceDbContext.DeliveryDetails.FindAsync(id);
            if (deliveryDetails != null)
            {
                deliveryDetailsModel.ApplyTo(deliveryDetails);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
