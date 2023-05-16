using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IKartDetailsRepository
    {
        List<KartDetailsModel> GetAllKartDetails();
        Task<List<KartDetailsModel>> GetAllKartDetailsAsync();

        KartDetailsModel GetKartDetailsById(int id);
        Task<KartDetailsModel> GetKartDetailsByIdAsync(int id);

        int AddKartDetails(KartDetailsModel kartDetailsModel);
        Task<int> AddKartDetailsAsync(KartDetailsModel kartDetailsModel);

        void UpdateKartDetails(int id, KartDetailsModel kartDetailsModel);
        Task UpdateKartDetailsAsync(int id, KartDetailsModel kartDetailsModel);

        void UpdateKartDetailsPatch(int id, JsonPatchDocument kartDetailsModel);
        Task UpdateKartDetailsPatchAsync(int id, JsonPatchDocument kartDetailsModel);

        void DeleteKartDetails(int id);
        Task DeleteKartDetailsAsync(int id);
    }
}
