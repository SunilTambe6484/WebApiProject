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
    public class ProductImagesRepository : IProductImagesRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public ProductImagesRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddProductImages(ProductImagesModel productImagesModel)
        {
            var productImages = _mapper.Map<ProductImagesModel, ProductImages>(productImagesModel);

            _ecommerceDbContext.Add(productImages);
            _ecommerceDbContext.SaveChanges();

            return productImages.ID;
        }

        public async Task<int> AddProductImagesAsync(ProductImagesModel productImagesModel)
        {
            var productImages = _mapper.Map<ProductImagesModel, ProductImages>(productImagesModel);

            _ecommerceDbContext.Add(productImages);
            await _ecommerceDbContext.SaveChangesAsync();

            return productImages.ID;
        }

        public void DeleteProductImages(int id)
        {
            var productImages = _ecommerceDbContext.ProductImages.Find(id);

            _ecommerceDbContext.ProductImages.Remove(productImages);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteProductImagesAsync(int id)
        {
            var productImages = await _ecommerceDbContext.ProductImages.FindAsync(id);

            _ecommerceDbContext.ProductImages.Remove(productImages);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<ProductImagesModel> GetAllProductImages()
        {
            var productImagesList = _ecommerceDbContext.ProductImages.ToList();
            return _mapper.Map<List<ProductImagesModel>>(productImagesList);
        }

        public async Task<List<ProductImagesModel>> GetAllProductImagesAsync()
        {
            var productImagesList = await _ecommerceDbContext.ProductImages.ToListAsync();
            return _mapper.Map<List<ProductImagesModel>>(productImagesList);
        }

        public ProductImagesModel GetProductImagesById(int id)
        {
            var productImages = _ecommerceDbContext.ProductImages.Find(id);
            return _mapper.Map<ProductImagesModel>(productImages);
        }

        public async Task<ProductImagesModel> GetProductImagesByIdAsync(int id)
        {
            var productImages = await _ecommerceDbContext.ProductImages.Where(a => a.ID == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductImagesModel>(productImages);
        }

        public void UpdateProductImages(int id, ProductImagesModel productImagesModel)
        {
            var productImages = _mapper.Map<ProductImagesModel, ProductImages>(productImagesModel);
            productImages.ID = id;

            _ecommerceDbContext.Entry(productImages).State = EntityState.Modified;
            _ecommerceDbContext.Entry(productImages).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(productImages).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateProductImagesAsync(int id, ProductImagesModel productImagesModel)
        {
            var productImages = _mapper.Map<ProductImagesModel, ProductImages>(productImagesModel);
            productImages.ID = id;

            _ecommerceDbContext.Entry(productImages).State = EntityState.Modified;
            _ecommerceDbContext.Entry(productImages).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(productImages).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateProductImagesPatch(int id, JsonPatchDocument productImagesModel)
        {
            var productImages = _ecommerceDbContext.ProductImages.Find(id);
            if (productImages != null)
            {
                productImagesModel.ApplyTo(productImages);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateProductImagesPatchAsync(int id, JsonPatchDocument productImagesModel)
        {
            var productImages = await _ecommerceDbContext.Countries.FindAsync(id);
            if (productImages != null)
            {
                productImagesModel.ApplyTo(productImages);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
