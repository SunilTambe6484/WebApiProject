using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface ICountryRepository
    {
        List<CountryModel> GetAllCountries();
        Task<List<CountryModel>> GetAllCountriesAsync();

        CountryModel GetCountryById(int id);
        Task<CountryModel> GetCountryByIdAsync(int id);

        int AddCountry(CountryModel countryModel);
        Task<int> AddCountryAsync(CountryModel countryModel);

        void UpdateCountry(int id, CountryModel countryModel);
        Task UpdateCountryAsync(int id, CountryModel countryModel);

        void UpdateCountryPatch(int id, JsonPatchDocument countryModel);
        Task UpdateCountryPatchAsync(int id, JsonPatchDocument countryModel);

        void DeleteCountry(int id);
        Task DeleteCountryAsync(int id);
    }
}
