using CoreWebApi.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;

namespace CoreWebApi.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public CountryRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddCountry(CountryModel countryModel)
        {
            var country = _mapper.Map<CountryModel, Country>(countryModel);

            _ecommerceDbContext.Add(country);
            _ecommerceDbContext.SaveChanges();

            return country.Id;
        }

        public async Task<int> AddCountryAsync(CountryModel countryModel)
        {
            var country = _mapper.Map<CountryModel, Country>(countryModel);

            _ecommerceDbContext.Add(country);
            await _ecommerceDbContext.SaveChangesAsync();

            return country.Id;
        }

        public void DeleteCountry(int id)
        {
            var country = _ecommerceDbContext.Countries.Find(id);

            _ecommerceDbContext.Countries.Remove(country);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteCountryAsync(int id)
        {
            var country = await _ecommerceDbContext.Countries.FindAsync(id);

            _ecommerceDbContext.Countries.Remove(country);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<CountryModel> GetAllCountries()
        {
            var countryList = _ecommerceDbContext.Countries.ToList();
            return _mapper.Map<List<CountryModel>>(countryList);
        }

        public async Task<List<CountryModel>> GetAllCountriesAsync()
        {
            var countryList = await _ecommerceDbContext.Countries.ToListAsync();
            return _mapper.Map<List<CountryModel>>(countryList);
        }

        public CountryModel GetCountryById(int id)
        {
            var country = _ecommerceDbContext.Countries.Find(id);
            return _mapper.Map<CountryModel>(country);
        }

        public async Task<CountryModel> GetCountryByIdAsync(int id)
        {
            var country = await _ecommerceDbContext.Countries.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<CountryModel>(country);
        }

        public void UpdateCountry(int id, CountryModel countryModel)
        {
            var country = _mapper.Map<CountryModel, Country>(countryModel);
            country.Id = id;

            _ecommerceDbContext.Entry(country).State = EntityState.Modified;
            _ecommerceDbContext.Entry(country).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(country).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();

        }

        public async Task UpdateCountryAsync(int id, CountryModel countryModel)
        {
            var country = _mapper.Map<CountryModel, Country>(countryModel);
            country.Id = id;

            _ecommerceDbContext.Entry(country).State = EntityState.Modified;
            _ecommerceDbContext.Entry(country).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(country).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();

        }

        public void UpdateCountryPatch(int id, JsonPatchDocument countryModel)
        {
            var country = _ecommerceDbContext.Countries.Find(id);
            if(country != null)
            {
                countryModel.ApplyTo(country);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateCountryPatchAsync(int id, JsonPatchDocument countryModel)
        {
            var country = await _ecommerceDbContext.Countries.FindAsync(id);
            if(country != null)
            {
                countryModel.ApplyTo(country);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
