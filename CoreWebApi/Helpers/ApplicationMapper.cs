using AutoMapper;
using CoreWebApi.DL;
using CoreWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<AddressType, AddressTypeModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<City, CityModel>().ReverseMap();
            CreateMap<Country, CountryModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<DeliveryDetails, DeliveryDetailsModel>().ReverseMap();
            CreateMap<DeliveryDetailsOrderMapper, DeliveryDetailsOrderMapperModel>().ReverseMap();
            CreateMap<DeliveryAddress, DeliveryAddressModel>().ReverseMap();
            CreateMap<KartDetails, KartDetailsModel>().ReverseMap();
            CreateMap<OrderDetails, OrderDetailsModel>().ReverseMap();
            CreateMap<OrderHistory, OrderHistoryModel>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductAvailibilityMapper, ProductAvailibilityMapperModel>().ReverseMap();
            CreateMap<ProductDeliveryExpectation, ProductDeliveryExpectationModel>().ReverseMap();
            CreateMap<ProductImages, ProductImagesModel>().ReverseMap();
            CreateMap<ProductShop, ProductShopModel>().ReverseMap();
            CreateMap<ProductSize, ProductSizeModel>().ReverseMap();
            CreateMap<ProductSpecification, ProductSpecificationModel>().ReverseMap();
            CreateMap<ProductSubType, ProductSubTypeModel>().ReverseMap();
            CreateMap<ProductType, ProductTypeModel>().ReverseMap();
            CreateMap<State, StateModel>().ReverseMap();
            CreateMap<SubCategory, SubCategoryModel>().ReverseMap();
            CreateMap<SubCategoryProductMapper, SubCategoryProductMapperModel>().ReverseMap();
            CreateMap<SubTypeProductMapper, SubTypeProductMapperModel>().ReverseMap();
        }
    }
}
