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
    public class KartDetailsRepository : IKartDetailsRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public KartDetailsRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddKartDetails(KartDetailsModel kartDetailsModel)
        {
            var kartDetails = _mapper.Map<KartDetailsModel, KartDetails>(kartDetailsModel);

            _ecommerceDbContext.Add(kartDetails);
            _ecommerceDbContext.SaveChanges();

            return kartDetails.Id;
        }

        public async Task<int> AddKartDetailsAsync(KartDetailsModel kartDetailsModel)
        {
            var kartDetails = _mapper.Map<KartDetailsModel, KartDetails>(kartDetailsModel);

            _ecommerceDbContext.Add(kartDetails);
            await _ecommerceDbContext.SaveChangesAsync();

            return kartDetails.Id;
        }
        
        public void DeleteKartDetails(int id)
        {
            var kartDetails = _ecommerceDbContext.KartDetails.Find(id);

            _ecommerceDbContext.KartDetails.Remove(kartDetails);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteKartDetailsAsync(int id)
        {
            var kartDetails = await _ecommerceDbContext.KartDetails.FindAsync(id);

            _ecommerceDbContext.KartDetails.Remove(kartDetails);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<KartDetailsModel> GetAllKartDetails()
        {
            var kartDetailsList = _ecommerceDbContext.KartDetails.ToList();
            return _mapper.Map<List<KartDetailsModel>>(kartDetailsList);
        }

        public async Task<List<KartDetailsModel>> GetAllKartDetailsAsync()
        {
            var kartDetailsList = await _ecommerceDbContext.KartDetails.ToListAsync();
            return _mapper.Map<List<KartDetailsModel>>(kartDetailsList);
        }

        public KartDetailsModel GetKartDetailsById(int id)
        {
            var kartDetails = _ecommerceDbContext.KartDetails.Find(id);
            return _mapper.Map<KartDetailsModel>(kartDetails);
        }

        public async Task<KartDetailsModel> GetKartDetailsByIdAsync(int id)
        {
            var kartDetails = await _ecommerceDbContext.KartDetails.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<KartDetailsModel>(kartDetails);
        }

        public void UpdateKartDetails(int id, KartDetailsModel kartDetailsModel)
        {
            var kartDetails = _mapper.Map<KartDetailsModel, KartDetails>(kartDetailsModel);
            kartDetails.Id = id;

            _ecommerceDbContext.Entry(kartDetails).State = EntityState.Modified;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateKartDetailsAsync(int id, KartDetailsModel kartDetailsModel)
        {
            var kartDetails = _mapper.Map<KartDetailsModel, KartDetails>(kartDetailsModel);
            kartDetails.Id = id;

            _ecommerceDbContext.Entry(kartDetails).State = EntityState.Modified;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateKartDetailsPatch(int id, JsonPatchDocument kartDetailsModel)
        {
            var kartDetails = _ecommerceDbContext.KartDetails.Find(id);
            if (kartDetails != null)
            {
                kartDetailsModel.ApplyTo(kartDetails);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateKartDetailsPatchAsync(int id, JsonPatchDocument kartDetailsModel)
        {
            var kartDetails = await _ecommerceDbContext.KartDetails.FindAsync(id);
            if (kartDetails != null)
            {
                kartDetailsModel.ApplyTo(kartDetails);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
