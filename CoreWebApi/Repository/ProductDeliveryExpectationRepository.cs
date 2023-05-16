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
    public class ProductDeliveryExpectationRepository : IProductDeliveryExpectationRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public ProductDeliveryExpectationRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddProductDeliveryExpectation(ProductDeliveryExpectationModel productDeliveryExpectationModel)
        {
            var productDeliveryExpectation = _mapper.Map<ProductDeliveryExpectationModel, ProductDeliveryExpectation>(productDeliveryExpectationModel);

            _ecommerceDbContext.Add(productDeliveryExpectation);
            _ecommerceDbContext.SaveChanges();

            return productDeliveryExpectation.ID;
        }

        public async Task<int> AddProductDeliveryExpectationAsync(ProductDeliveryExpectationModel productDeliveryExpectationModel)
        {
            var productDeliveryExpectation = _mapper.Map<ProductDeliveryExpectationModel, ProductDeliveryExpectation>(productDeliveryExpectationModel);

            _ecommerceDbContext.Add(productDeliveryExpectation);
            await _ecommerceDbContext.SaveChangesAsync();

            return productDeliveryExpectation.ID;
        }

        public void DeleteProductDeliveryExpectation(int id)
        {
            var productDeliveryExpectation = _ecommerceDbContext.ProductDeliveryExpectations.Find(id);

            _ecommerceDbContext.ProductDeliveryExpectations.Remove(productDeliveryExpectation);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteProductDeliveryExpectationAsync(int id)
        {
            var productDeliveryExpectations = await _ecommerceDbContext.ProductDeliveryExpectations.FindAsync(id);

            _ecommerceDbContext.ProductDeliveryExpectations.Remove(productDeliveryExpectations);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<ProductDeliveryExpectationModel> GetAllProductDeliveryExpectation()
        {
            var productDeliveryExpectationsList = _ecommerceDbContext.ProductDeliveryExpectations.ToList();
            return _mapper.Map<List<ProductDeliveryExpectationModel>>(productDeliveryExpectationsList);
        }

        public async Task<List<ProductDeliveryExpectationModel>> GetAllProductDeliveryExpectationAsync()
        {
            var productDeliveryExpectationsList = await _ecommerceDbContext.ProductDeliveryExpectations.ToListAsync();
            return _mapper.Map<List<ProductDeliveryExpectationModel>>(productDeliveryExpectationsList);
        }

        public ProductDeliveryExpectationModel GetProductDeliveryExpectationById(int id)
        {
            var productDeliveryExpectations = _ecommerceDbContext.ProductDeliveryExpectations.Find(id);
            return _mapper.Map<ProductDeliveryExpectationModel>(productDeliveryExpectations);
        }

        public async Task<ProductDeliveryExpectationModel> GetProductDeliveryExpectationByIdAsync(int id)
        {
            var productDeliveryExpectations = await _ecommerceDbContext.ProductDeliveryExpectations.Where(a => a.ID == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDeliveryExpectationModel>(productDeliveryExpectations);
        }

        public void UpdateProductDeliveryExpectation(int id, ProductDeliveryExpectationModel productDeliveryExpectationModel)
        {
            var productDeliveryExpectation = _mapper.Map<ProductDeliveryExpectationModel, ProductDeliveryExpectation>(productDeliveryExpectationModel);
            productDeliveryExpectation.ID = id;

            _ecommerceDbContext.Entry(productDeliveryExpectation).State = EntityState.Modified;
            _ecommerceDbContext.Entry(productDeliveryExpectation).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(productDeliveryExpectation).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateProductDeliveryExpectationAsync(int id, ProductDeliveryExpectationModel productDeliveryExpectationModel)
        {
            var productDeliveryExpectation = _mapper.Map<ProductDeliveryExpectationModel, ProductDeliveryExpectation>(productDeliveryExpectationModel);
            productDeliveryExpectation.ID = id;

            _ecommerceDbContext.Entry(productDeliveryExpectation).State = EntityState.Modified;
            _ecommerceDbContext.Entry(productDeliveryExpectation).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(productDeliveryExpectation).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateProductDeliveryExpectationPatch(int id, JsonPatchDocument productDeliveryExpectationModel)
        {
            var productDeliveryExpectation = _ecommerceDbContext.ProductDeliveryExpectations.Find(id);
            if (productDeliveryExpectation != null)
            {
                productDeliveryExpectationModel.ApplyTo(productDeliveryExpectation);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateProductDeliveryExpectationPatchAsync(int id, JsonPatchDocument productDeliveryExpectationModel)
        {
            var productDeliveryExpectation = await _ecommerceDbContext.ProductDeliveryExpectations.FindAsync(id);
            if (productDeliveryExpectation != null)
            {
                productDeliveryExpectationModel.ApplyTo(productDeliveryExpectation);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
