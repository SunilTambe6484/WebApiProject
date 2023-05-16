using CoreWebApi.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DL
{
    public class ECommerceDbContext : IdentityDbContext<ApplicationUser>
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            :base(options)
        {

        }

        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryDetails> DeliveryDetails { get; set; }
        public DbSet<DeliveryDetailsOrderMapper> DeliveryDetailsOrderMappers { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<KartDetails> KartDetails { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductAvailibilityMapper> ProductAvailibilityMappers { get; set; }
        public DbSet<ProductDeliveryExpectation> ProductDeliveryExpectations { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductShop> ProductShops { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<ProductSubType> ProductSubTypes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SubCategoryProductMapper> SubCategoryProductMappers { get; set; }
        public DbSet<SubTypeProductMapper> SubTypeProductMappers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<AddressType>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<Category>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<City>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<Customer>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<DeliveryDetails>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<DeliveryAddress>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<PaymentMethod>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<ProductModel>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<ProductImages>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<ProductSize>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<ProductShop>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<ProductSpecification>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<ProductSubType>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<ProductType>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<State>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<SubCategory>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Entity<ProductDeliveryExpectation>()
                .Property(c => c.UpdationDate)
                .IsRequired(false);

            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserRole<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityUser<string>>();
            builder.Ignore<ApplicationUser>();
        }
    }
}
