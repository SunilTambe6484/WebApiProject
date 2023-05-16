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
    public class CityRepository : ICityRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public CityRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddCity(CityModel cityModel)
        {
            var city = _mapper.Map<CityModel, City>(cityModel);

            _ecommerceDbContext.Add(city);
            _ecommerceDbContext.SaveChanges();

            return city.Id;
        }

        public async Task<int> AddCityAsync(CityModel cityModel)
        {
            var city = _mapper.Map<CityModel, City>(cityModel);

            _ecommerceDbContext.Add(city);
            await _ecommerceDbContext.SaveChangesAsync();

            return city.Id;
        }

        public void DeleteCity(int id)
        {
            var city = _ecommerceDbContext.Cities.Find(id);

            _ecommerceDbContext.Cities.Remove(city);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteCityAsync(int id)
        {
            var city = await _ecommerceDbContext.Cities.FindAsync(id);

            _ecommerceDbContext.Cities.Remove(city);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<CityModel> GetAllCities()
        {
            var cityList = _ecommerceDbContext.Cities.ToList();
            return _mapper.Map<List<CityModel>>(cityList);
        }

        public async Task<List<CityModel>> GetAllCitiesAsync()
        {
            var cityList = await _ecommerceDbContext.Cities.ToListAsync();
            return _mapper.Map<List<CityModel>>(cityList);
        }

        public CityModel GetCityById(int id)
        {
            var city = _ecommerceDbContext.Cities.Find(id);
            return _mapper.Map<CityModel>(city);
        }

        public async Task<CityModel> GetCityByIdAsync(int id)
        {
            var city = await _ecommerceDbContext.Cities.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<CityModel>(city);
        }

        public List<CityModel> GetCityByStateId(int stateId)
        {
            var cityList = _ecommerceDbContext.Cities.Where(a => a.StateId == stateId).ToList();
            return _mapper.Map<List<CityModel>>(cityList);
        }

        public async Task<List<CityModel>> GetCityByStateIdAsync(int stateId)
        {
            var cityList = await _ecommerceDbContext.Cities.Where(a => a.StateId == stateId).ToListAsync();
            return _mapper.Map<List<CityModel>>(cityList);
        }

        public void UpdateCity(int id, CityModel cityModel)
        {
            var city = _mapper.Map<CityModel, City>(cityModel);
            city.Id = id;

            _ecommerceDbContext.Entry(city).State = EntityState.Modified;
            _ecommerceDbContext.Entry(city).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(city).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateCityAsync(int id, CityModel cityModel)
        {
            var city = _mapper.Map<CityModel, City>(cityModel);
            city.Id = id;

            _ecommerceDbContext.Entry(city).State = EntityState.Modified;
            _ecommerceDbContext.Entry(city).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(city).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateCityPatch(int id, JsonPatchDocument cityModel)
        {
            var city = _ecommerceDbContext.Cities.Find(id);
            if (city != null)
            {
                cityModel.ApplyTo(city);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateCityPatchAsync(int id, JsonPatchDocument cityModel)
        {
            var city = await _ecommerceDbContext.Cities.FindAsync(id);
            if (city != null)
            {
                cityModel.ApplyTo(city);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
