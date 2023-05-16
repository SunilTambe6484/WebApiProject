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
    public class ProductShopRepository : IProductShopRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public ProductShopRepository(ECommerceDbContext _commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = _commerceDbContext;
            _mapper = mapper;
        }
        public int AddProductShop(ProductShopModel productShopModel)
        {
            var productShop = _mapper.Map<ProductShopModel, ProductShop>(productShopModel);

            _ecommerceDbContext.Add(productShop);
            _ecommerceDbContext.SaveChanges();

            return productShop.Id;
        }

        public async Task<int> AddProductShopAsync(ProductShopModel productShopModel)
        {
            var productShop = _mapper.Map<ProductShopModel, ProductShop>(productShopModel);

            _ecommerceDbContext.Add(productShop);
            await _ecommerceDbContext.SaveChangesAsync();

            return productShop.Id;
        }

        public void DeleteProductShop(int id)
        {
            var productShops = _ecommerceDbContext.ProductShops.Find(id);

            _ecommerceDbContext.ProductShops.Remove(productShops);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteProductShopAsync(int id)
        {
            var productShops = await _ecommerceDbContext.ProductShops.FindAsync(id);

            _ecommerceDbContext.ProductShops.Remove(productShops);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<ProductShopModel> GetAllProductShops()
        {
            var productShopsList = _ecommerceDbContext.ProductShops.ToList();
            return _mapper.Map<List<ProductShopModel>>(productShopsList);
        }

        public async Task<List<ProductShopModel>> GetAllProductShopsAsync()
        {
            var productShopsList = await _ecommerceDbContext.ProductShops.ToListAsync();
            return _mapper.Map<List<ProductShopModel>>(productShopsList);
        }

        public ProductShopModel GetProductShopById(int id)
        {
            var productShop = _ecommerceDbContext.ProductShops.Find(id);
            return _mapper.Map<ProductShopModel>(productShop);
        }

        public async Task<ProductShopModel> GetProductShopByIdAsync(int id)
        {
            var productShops = await _ecommerceDbContext.ProductShops.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductShopModel>(productShops);
        }

        public void UpdateProductShop(int id, ProductShopModel productShopModel)
        {
            var productShop = _mapper.Map<ProductShopModel, ProductShop>(productShopModel);
            productShop.Id = id;

            _ecommerceDbContext.Entry(productShop).State = EntityState.Modified;
            _ecommerceDbContext.Entry(productShop).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(productShop).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateProductShopAsync(int id, ProductShopModel productShopModel)
        {
            var productShop = _mapper.Map<ProductShopModel, ProductShop>(productShopModel);
            productShop.Id = id;

            _ecommerceDbContext.Entry(productShop).State = EntityState.Modified;
            _ecommerceDbContext.Entry(productShop).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(productShop).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public async void UpdateProductShopPatch(int id, JsonPatchDocument productShopModel)
        {
            var productShop = _ecommerceDbContext.ProductShops.Find(id);
            if (productShop != null)
            {
                productShopModel.ApplyTo(productShop);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateProductShopPatchAsync(int id, JsonPatchDocument productShopModel)
        {
            var productShop = await _ecommerceDbContext.ProductShops.FindAsync(id);
            if (productShop != null)
            {
                productShopModel.ApplyTo(productShop);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
