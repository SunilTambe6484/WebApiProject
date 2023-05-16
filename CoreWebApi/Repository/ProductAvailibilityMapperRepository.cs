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
    public class ProductAvailibilityMapperRepository : IProductAvailibilityMapperRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public ProductAvailibilityMapperRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddProductAvailibilityMapper(ProductAvailibilityMapperModel productAvailibilityMapperModel)
        {
            var productAvailibilityMapper = _mapper.Map<ProductAvailibilityMapperModel, ProductAvailibilityMapper>(productAvailibilityMapperModel);

            _ecommerceDbContext.Add(productAvailibilityMapper);
            _ecommerceDbContext.SaveChanges();

            return productAvailibilityMapper.Id;
        }

        public async Task<int> AddProductAvailibilityMapperAsync(ProductAvailibilityMapperModel productAvailibilityMapperModel)
        {
            var productAvailibilityMapper = _mapper.Map<ProductAvailibilityMapperModel, ProductAvailibilityMapper>(productAvailibilityMapperModel);

            _ecommerceDbContext.Add(productAvailibilityMapper);
            await _ecommerceDbContext.SaveChangesAsync();

            return productAvailibilityMapper.Id;
        }

        public void DeleteProductAvailibilityMapper(int id)
        {
            var productAvailibilityMapper = _ecommerceDbContext.ProductAvailibilityMappers.Find(id);

            _ecommerceDbContext.ProductAvailibilityMappers.Remove(productAvailibilityMapper);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteProductAvailibilityMapperAsync(int id)
        {
            var productAvailibilityMapper = await _ecommerceDbContext.ProductAvailibilityMappers.FindAsync(id);

            _ecommerceDbContext.ProductAvailibilityMappers.Remove(productAvailibilityMapper);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<ProductAvailibilityMapperModel> GetAllProductAvailibilityMapper()
        {
            var productAvailibilityMapperList = _ecommerceDbContext.ProductAvailibilityMappers.ToList();
            return _mapper.Map<List<ProductAvailibilityMapperModel>>(productAvailibilityMapperList);
        }

        public async Task<List<ProductAvailibilityMapperModel>> GetAllProductAvailibilityMapperAsync()
        {
            var productAvailibilityMapperList = await _ecommerceDbContext.ProductAvailibilityMappers.ToListAsync();
            return _mapper.Map<List<ProductAvailibilityMapperModel>>(productAvailibilityMapperList);
        }

        public ProductAvailibilityMapperModel GetProductAvailibilityMapperById(int id)
        {
            var productAvailibilityMapper = _ecommerceDbContext.ProductAvailibilityMappers.Find(id);
            return _mapper.Map<ProductAvailibilityMapperModel>(productAvailibilityMapper);
        }

        public async Task<ProductAvailibilityMapperModel> GetProductAvailibilityMapperByIdAsync(int id)
        {
            var productAvailibilityMapper = await _ecommerceDbContext.ProductAvailibilityMappers.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductAvailibilityMapperModel>(productAvailibilityMapper);
        }

        public void UpdateProductAvailibilityMapper(int id, ProductAvailibilityMapperModel productAvailibilityMapperModel)
        {
            var productAvailibilityMapper = _mapper.Map<ProductAvailibilityMapperModel, ProductAvailibilityMapper>(productAvailibilityMapperModel);
            productAvailibilityMapper.Id = id;

            _ecommerceDbContext.Entry(productAvailibilityMapper).State = EntityState.Modified;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateProductAvailibilityMapperAsync(int id, ProductAvailibilityMapperModel productAvailibilityMapperModel)
        {
            var productAvailibilityMapper = _mapper.Map<ProductAvailibilityMapperModel, ProductAvailibilityMapper>(productAvailibilityMapperModel);
            productAvailibilityMapper.Id = id;

            _ecommerceDbContext.Entry(productAvailibilityMapper).State = EntityState.Modified;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateProductAvailibilityMapperPatch(int id, JsonPatchDocument productAvailibilityMapperModel)
        {
            var productAvailibilityMapper = _ecommerceDbContext.ProductAvailibilityMappers.Find(id);
            if (productAvailibilityMapper != null)
            {
                productAvailibilityMapperModel.ApplyTo(productAvailibilityMapper);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateProductAvailibilityMapperPatchAsync(int id, JsonPatchDocument productAvailibilityMapperModel)
        {
            var productAvailibilityMapper = await _ecommerceDbContext.ProductAvailibilityMappers.FindAsync(id);
            if (productAvailibilityMapper != null)
            {
                productAvailibilityMapperModel.ApplyTo(productAvailibilityMapper);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
