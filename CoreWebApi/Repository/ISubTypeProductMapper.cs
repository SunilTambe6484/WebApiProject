using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface ISubTypeProductMapperRepository
    {
        List<SubTypeProductMapperModel> GetAllSubTypeProductMapper();
        Task<List<SubTypeProductMapperModel>> GetAllSubTypeProductMapperAsync();

        SubTypeProductMapperModel GetSubTypeProductMapperById(int id);
        Task<SubTypeProductMapperModel> GetSubTypeProductMapperByIdAsync(int id);

        int AddSubTypeProductMapper(SubTypeProductMapperModel subTypeProductMapperModel);
        Task<int> AddSubTypeProductMapperAsync(SubTypeProductMapperModel subTypeProductMapperModel);

        void UpdateSubTypeProductMapper(int id, SubTypeProductMapperModel subTypeProductMapperModel);
        Task UpdateSubTypeProductMapperAsync(int id, SubTypeProductMapperModel subTypeProductMapperModel);

        void UpdateSubTypeProductMapperPatch(int id, JsonPatchDocument subTypeProductMapperModel);
        Task UpdateSubTypeProductMapperPatchAsync(int id, JsonPatchDocument subTypeProductMapperModel);

        void DeleteSubTypeProductMapper(int id);
        Task DeleteSubTypeProductMapperAsync(int id);
    }
}
