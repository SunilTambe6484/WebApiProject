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
    public class ProductSubTypeRepository : IProductSubTypeRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public ProductSubTypeRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddProductSubType(ProductSubTypeModel productSubTypeModel)
        {
            var productSubType = _mapper.Map<ProductSubTypeModel, ProductSubType>(productSubTypeModel);

            _ecommerceDbContext.Add(productSubType);
            _ecommerceDbContext.SaveChanges();

            return productSubType.Id;
        }

        public async Task<int> AddProductSubTypeAsync(ProductSubTypeModel productSubTypeModel)
        {
            var productSubType = _mapper.Map<ProductSubTypeModel, ProductSubType>(productSubTypeModel);

            _ecommerceDbContext.Add(productSubType);
            await _ecommerceDbContext.SaveChangesAsync();

            return productSubType.Id;
        }

        public void DeleteProductSubType(int id)
        {
            var productSubType = _ecommerceDbContext.ProductSubTypes.Find(id);

            _ecommerceDbContext.ProductSubTypes.Remove(productSubType);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteProductSubTypeAsync(int id)
        {
            var productSubType = await _ecommerceDbContext.ProductSubTypes.FindAsync(id);

            _ecommerceDbContext.ProductSubTypes.Remove(productSubType);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<ProductSubTypeModel> GetAllProductSubType()
        {
            var productSubTypesList = _ecommerceDbContext.ProductSubTypes.ToList();
            return _mapper.Map<List<ProductSubTypeModel>>(productSubTypesList);
        }

        public async Task<List<ProductSubTypeModel>> GetAllProductSubTypeAsync()
        {
            var productSubTypesList = await _ecommerceDbContext.ProductSubTypes.ToListAsync();
            return _mapper.Map<List<ProductSubTypeModel>>(productSubTypesList);
        }

        public ProductSubTypeModel GetProductSubTypeById(int id)
        {
            var productSubType = _ecommerceDbContext.ProductSubTypes.Find(id);
            return _mapper.Map<ProductSubTypeModel>(productSubType);
        }

        public async Task<ProductSubTypeModel> GetProductSubTypeByIdAsync(int id)
        {
            var productSubType = await _ecommerceDbContext.ProductSubTypes.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductSubTypeModel>(productSubType);
        }

        public void UpdateProductSubType(int id, ProductSubTypeModel productSubTypeModel)
        {
            var productSubType = _mapper.Map<ProductSubTypeModel, ProductSubType>(productSubTypeModel);
            productSubType.Id = id;

            _ecommerceDbContext.Entry(productSubType).State = EntityState.Modified;
            _ecommerceDbContext.Entry(productSubType).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(productSubType).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateProductSubTypeAsync(int id, ProductSubTypeModel productSubTypeModel)
        {
            var productSubType = _mapper.Map<ProductSubTypeModel, ProductSubType>(productSubTypeModel);
            productSubType.Id = id;

            _ecommerceDbContext.Entry(productSubType).State = EntityState.Modified;
            _ecommerceDbContext.Entry(productSubType).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(productSubType).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateProductSubTypePatch(int id, JsonPatchDocument productSubTypeModel)
        {
            var productSubType = _ecommerceDbContext.ProductSubTypes.Find(id);
            if (productSubType != null)
            {
                productSubTypeModel.ApplyTo(productSubType);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateProductSubTypePatchAsync(int id, JsonPatchDocument productSubTypeModel)
        {
            var productSubType = await _ecommerceDbContext.ProductSubTypes.FindAsync(id);
            if (productSubType != null)
            {
                productSubTypeModel.ApplyTo(productSubType);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
