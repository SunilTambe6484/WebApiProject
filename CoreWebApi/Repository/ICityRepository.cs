using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface ICityRepository
    {
        List<CityModel> GetAllCities();
        Task<List<CityModel>> GetAllCitiesAsync();

        CityModel GetCityById(int id);
        Task<CityModel> GetCityByIdAsync(int id);

        List<CityModel> GetCityByStateId(int stateId);
        Task<List<CityModel>> GetCityByStateIdAsync(int stateId);

        int AddCity(CityModel City);
        Task<int> AddCityAsync(CityModel City);

        void UpdateCity(int id, CityModel City);
        Task UpdateCityAsync(int id, CityModel City);

        void UpdateCityPatch(int id, JsonPatchDocument City);
        Task UpdateCityPatchAsync(int id, JsonPatchDocument City);

        void DeleteCity(int id);
        Task DeleteCityAsync(int id);
    }
}
