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
    public class StateRepository : IStateRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public StateRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }
        public int AddState(StateModel stateModel)
        {
            var state = _mapper.Map<StateModel, State>(stateModel);

            _ecommerceDbContext.Add(state);
            _ecommerceDbContext.SaveChanges();

            return state.Id;
        }

        public async Task<int> AddStateAsync(StateModel stateModel)
        {
            var state = _mapper.Map<StateModel, State>(stateModel);

            _ecommerceDbContext.Add(state);
            await _ecommerceDbContext.SaveChangesAsync();

            return state.Id;
        }

        public void DeleteState(int id)
        {
            var state = _ecommerceDbContext.States.Find(id);

            _ecommerceDbContext.States.Remove(state);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteStateAsync(int id)
        {
            var state = await _ecommerceDbContext.States.FindAsync(id);

            _ecommerceDbContext.States.Remove(state);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<StateModel> GetAllStates()
        {
            var stateList = _ecommerceDbContext.States.ToList();
            return _mapper.Map<List<StateModel>>(stateList);
        }

        public async Task<List<StateModel>> GetAllStatesAsync()
        {
            var stateList = await _ecommerceDbContext.States.ToListAsync();
            return _mapper.Map<List<StateModel>>(stateList);
        }

        public StateModel GetStateById(int id)
        {
            var state = _ecommerceDbContext.States.Find(id);
            return _mapper.Map<StateModel>(state);
        }

        public async Task<StateModel> GetStateByIdAsync(int id)
        {
            var state = await _ecommerceDbContext.States.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<StateModel>(state);
        }

        public List<StateModel> GetStateByCountryId(int countryId)
        {
            var stateList = _ecommerceDbContext.States.Where(a => a.CountryId == countryId).ToList();
            return _mapper.Map<List<StateModel>>(stateList);
        }

        public async Task<List<StateModel>> GetStateByCountryIdAsync(int countryId)
        {
            var stateList = await _ecommerceDbContext.States.Where(a => a.CountryId == countryId).ToListAsync();
            return _mapper.Map<List<StateModel>>(stateList);
        }

        public void UpdateState(int id, StateModel stateModel)
        {
            var state = _mapper.Map<StateModel, State>(stateModel);
            state.Id = id;

            _ecommerceDbContext.Entry(state).State = EntityState.Modified;
            _ecommerceDbContext.Entry(state).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(state).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateStateAsync(int id, StateModel stateModel)
        {
            var state = _mapper.Map<StateModel, State>(stateModel);
            state.Id = id;

            _ecommerceDbContext.Entry(state).State = EntityState.Modified;
            _ecommerceDbContext.Entry(state).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(state).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateStatePatch(int id, JsonPatchDocument stateModel)
        {
            var state = _ecommerceDbContext.States.Find(id);
            if (state != null)
            {
                stateModel.ApplyTo(state);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateStatePatchAsync(int id, JsonPatchDocument stateModel)
        {
            var state = await _ecommerceDbContext.States.FindAsync(id);
            if (state != null)
            {
                stateModel.ApplyTo(state);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
