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
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public ProductRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddProduct(ProductModel productModel)
        {
            var product = _mapper.Map<ProductModel, Product>(productModel);

            _ecommerceDbContext.Add(product);
            _ecommerceDbContext.SaveChanges();

            return product.Id;
        }

        public async Task<int> AddProductAsync(ProductModel productModel)
        {
            var product = _mapper.Map<ProductModel, Product>(productModel);

            _ecommerceDbContext.Add(product);
            await _ecommerceDbContext.SaveChangesAsync();

            return product.Id;
        }

        public void DeleteProduct(int id)
        {
            var products = _ecommerceDbContext.Product.Find(id);

            _ecommerceDbContext.Product.Remove(products);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteProductAsync(int id)
        {
            var products = await _ecommerceDbContext.Product.FindAsync(id);

            _ecommerceDbContext.Product.Remove(products);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<ProductModel> GetAllProducts()
        {
            var productList = _ecommerceDbContext.Product.ToList();
            return _mapper.Map<List<ProductModel>>(productList);
        }

        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            var productList = await _ecommerceDbContext.Product.ToListAsync();
            return _mapper.Map<List<ProductModel>>(productList);
        }

        public ProductModel GetProductById(int id)
        {
            var product = _ecommerceDbContext.Product.Find(id);
            return _mapper.Map<ProductModel>(product);
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            var product = await _ecommerceDbContext.Product.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductModel>(product);
        }

        public void UpdateProduct(int id, ProductModel productModel)
        {
            var product = _mapper.Map<ProductModel, Product>(productModel);
            product.Id = id;

            _ecommerceDbContext.Entry(product).State = EntityState.Modified;
            _ecommerceDbContext.Entry(product).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(product).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateProductAsync(int id, ProductModel productModel)
        {
            var product = _mapper.Map<ProductModel, Product>(productModel);
            product.Id = id;

            _ecommerceDbContext.Entry(product).State = EntityState.Modified;
            _ecommerceDbContext.Entry(product).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(product).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateProductPatch(int id, JsonPatchDocument productModel)
        {
            var product = _ecommerceDbContext.Product.Find(id);
            if (product != null)
            {
                productModel.ApplyTo(product);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateProductPatchAsync(int id, JsonPatchDocument productModel)
        {
            var products = await _ecommerceDbContext.Product.FindAsync(id);
            if (products != null)
            {
                productModel.ApplyTo(products);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
