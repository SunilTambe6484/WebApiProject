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
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public ProductTypeRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddProductType(ProductTypeModel productTypeModel)
        {
            var productType = _mapper.Map<ProductTypeModel, ProductType>(productTypeModel);

            _ecommerceDbContext.Add(productType);
            _ecommerceDbContext.SaveChanges();

            return productType.Id;
        }

        public async Task<int> AddProductTypeAsync(ProductTypeModel productTypeModel)
        {
            var productType = _mapper.Map<ProductTypeModel, ProductType>(productTypeModel);

            _ecommerceDbContext.Add(productType);
            await _ecommerceDbContext.SaveChangesAsync();

            return productType.Id;
        }

        public void DeleteProductType(int id)
        {
            var productType = _ecommerceDbContext.ProductTypes.Find(id);

            _ecommerceDbContext.ProductTypes.Remove(productType);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteProductTypeAsync(int id)
        {
            var productType = await _ecommerceDbContext.ProductTypes.FindAsync(id);

            _ecommerceDbContext.ProductTypes.Remove(productType);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<ProductTypeModel> GetAllProductType()
        {
            var productTypeList = _ecommerceDbContext.ProductTypes.ToList();
            return _mapper.Map<List<ProductTypeModel>>(productTypeList);
        }

        public async Task<List<ProductTypeModel>> GetAllProductTypeAsync()
        {
            var productTypeList = await _ecommerceDbContext.ProductTypes.ToListAsync();
            return _mapper.Map<List<ProductTypeModel>>(productTypeList);
        }

        public ProductTypeModel GetProductTypeById(int id)
        {
            var productType = _ecommerceDbContext.ProductTypes.Find(id);
            return _mapper.Map<ProductTypeModel>(productType);
        }

        public async Task<ProductTypeModel> GetProductTypeByIdAsync(int id)
        {
            var productType = await _ecommerceDbContext.ProductTypes.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductTypeModel>(productType);
        }

        public void UpdateProductType(int id, ProductTypeModel productTypeModel)
        {
            var productType = _mapper.Map<ProductTypeModel, ProductType>(productTypeModel);
            productType.Id = id;

            _ecommerceDbContext.Entry(productType).State = EntityState.Modified;
            _ecommerceDbContext.Entry(productType).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(productType).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateProductTypeAsync(int id, ProductTypeModel productTypeModel)
        {
            var productType = _mapper.Map<ProductTypeModel, ProductType>(productTypeModel);
            productType.Id = id;

            _ecommerceDbContext.Entry(productType).State = EntityState.Modified;
            _ecommerceDbContext.Entry(productType).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(productType).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateProductTypePatch(int id, JsonPatchDocument productTypeModel)
        {
            var productType = _ecommerceDbContext.ProductTypes.Find(id);
            if (productType != null)
            {
                productTypeModel.ApplyTo(productType);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateProductTypePatchAsync(int id, JsonPatchDocument productTypeModel)
        {
            var productType = await _ecommerceDbContext.ProductTypes.FindAsync(id);
            if (productType != null)
            {
                productTypeModel.ApplyTo(productType);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
