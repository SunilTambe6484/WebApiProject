using CoreWebApi.DL;
using CoreWebApi.Model;
using CoreWebApi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ECommerceDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("EcommerceSiteDb")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ECommerceDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllers();

            //services.AddTransient<typeof(IGenericRepository<>), typeof(GenericRepository<>)>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IAddressTypeRepository, AddressTypeRepository>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IDeliveryAddressRepository, DeliveryAddressRepository>();
            services.AddTransient<IDeliveryDetailsOrderMapperRepository, DeliveryDetailsOrderMapperRepository>();
            services.AddTransient<IKartDetailsRepository, KartDetailsRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IDeliveryDetailsRepository, DeliveryDetailsRepository>();
            services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddTransient<IProductDeliveryExpectationRepository, ProductDeliveryExpectationRepository>();
            services.AddTransient<IProductImagesRepository, ProductImagesRepository>();
            services.AddTransient<IProductShopRepository, ProductShopRepository>();
            services.AddTransient<IProductSpecificationRepository, ProductSpecificationRepository>();
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
            services.AddTransient<IProductSubTypeRepository, ProductSubTypeRepository>();
            services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();
            services.AddTransient<IProductAvailibilityMapperRepository, ProductAvailibilityMapperRepository>();
            services.AddTransient<ISubTypeProductMapperRepository, SubTypeProductMapperRepository>();
            services.AddTransient<ISubCategoryProductMapperRepository, SubCategoryProductMapperRepository>();
            services.AddTransient<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddTransient<IOrderHistoryRepository, OrderHistoryRepository>();
            services.AddTransient<IDeliveryDetailsOrderMapperRepository, DeliveryDetailsOrderMapperRepository>();


            services.AddAutoMapper(typeof(Startup));

        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
