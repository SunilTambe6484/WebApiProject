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
    public class ProductSpecificationRepository : IProductSpecificationRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public ProductSpecificationRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddProductSpecification(ProductSpecificationModel productSpecificationModel)
        {
            var productSpecification = _mapper.Map<ProductSpecificationModel, ProductSpecification>(productSpecificationModel);

            _ecommerceDbContext.Add(productSpecification);
            _ecommerceDbContext.SaveChanges();

            return productSpecification.Id;
        }

        public async Task<int> AddProductSpecificationAsync(ProductSpecificationModel productSpecificationModel)
        {
            var productSpecification = _mapper.Map<ProductSpecificationModel, ProductSpecification>(productSpecificationModel);

            _ecommerceDbContext.Add(productSpecification);
            await _ecommerceDbContext.SaveChangesAsync();

            return productSpecification.Id;
        }

        public void DeleteProductSpecification(int id)
        {
            var productSpecifications = _ecommerceDbContext.ProductSpecifications.Find(id);

            _ecommerceDbContext.ProductSpecifications.Remove(productSpecifications);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteProductSpecificationAsync(int id)
        {
            var productSpecification = await _ecommerceDbContext.ProductSpecifications.FindAsync(id);

            _ecommerceDbContext.ProductSpecifications.Remove(productSpecification);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<ProductSpecificationModel> GetAllProductSpecification()
        {
            var productSpecificationList = _ecommerceDbContext.ProductSpecifications.ToList();
            return _mapper.Map<List<ProductSpecificationModel>>(productSpecificationList);
        }

        public async Task<List<ProductSpecificationModel>> GetAllProductSpecificationAsync()
        {
            var productSpecificationList = await _ecommerceDbContext.ProductSpecifications.ToListAsync();
            return _mapper.Map<List<ProductSpecificationModel>>(productSpecificationList);
        }

        public ProductSpecificationModel GetProductSpecificationById(int id)
        {
            var productSpecification = _ecommerceDbContext.ProductSpecifications.Find(id);
            return _mapper.Map<ProductSpecificationModel>(productSpecification);
        }

        public async Task<ProductSpecificationModel> GetProductSpecificationByIdAsync(int id)
        {
            var productSpecification = await _ecommerceDbContext.ProductSpecifications.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductSpecificationModel>(productSpecification);
        }

        public void UpdateProductSpecification(int id, ProductSpecificationModel productSpecificationModel)
        {
            var productSpecification = _mapper.Map<ProductSpecificationModel, ProductSpecification>(productSpecificationModel);
            productSpecification.Id = id;

            _ecommerceDbContext.Entry(productSpecification).State = EntityState.Modified;
            _ecommerceDbContext.Entry(productSpecification).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(productSpecification).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateProductSpecificationAsync(int id, ProductSpecificationModel productSpecificationModel)
        {
            var productSpecification = _mapper.Map<ProductSpecificationModel, ProductSpecification>(productSpecificationModel);
            productSpecification.Id = id;

            _ecommerceDbContext.Entry(productSpecification).State = EntityState.Modified;
            _ecommerceDbContext.Entry(productSpecification).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(productSpecification).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateProductSpecificationPatch(int id, JsonPatchDocument productSpecificationModel)
        {
            var productSpecification = _ecommerceDbContext.ProductSpecifications.Find(id);
            if (productSpecification != null)
            {
                productSpecificationModel.ApplyTo(productSpecification);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateProductSpecificationPatchAsync(int id, JsonPatchDocument productSpecificationModel)
        {
            var productSpecification = await _ecommerceDbContext.ProductSpecifications.FindAsync(id);
            if (productSpecification != null)
            {
                productSpecificationModel.ApplyTo(productSpecification);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
