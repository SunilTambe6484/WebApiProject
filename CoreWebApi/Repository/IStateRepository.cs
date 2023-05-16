using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IStateRepository
    {
        List<StateModel> GetAllStates();
        Task<List<StateModel>> GetAllStatesAsync();

        StateModel GetStateById(int id);
        Task<StateModel> GetStateByIdAsync(int id);

        List<StateModel> GetStateByCountryId(int countryId);
        Task<List<StateModel>> GetStateByCountryIdAsync(int countryId);

        int AddState(StateModel stateModel);
        Task<int> AddStateAsync(StateModel stateModel);

        void UpdateState(int id, StateModel stateModel);
        Task UpdateStateAsync(int id, StateModel stateModel);

        void UpdateStatePatch(int id, JsonPatchDocument State);
        Task UpdateStatePatchAsync(int id, JsonPatchDocument State);

        void DeleteState(int id);
        Task DeleteStateAsync(int id);
    }
}
