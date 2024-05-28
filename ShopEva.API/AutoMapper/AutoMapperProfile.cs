using AutoMapper;
using ShopEva.Data.ViewModels;
using ShopEva.Models.Model;

namespace ShopEva.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductDetail, ProductDetailViewModel>();
            CreateMap<ProductProductCategory, ProductCategoriesViewModel>();
            CreateMap<Sys_Status, StatusViewModel>();
            CreateMap<ApplicationUser, UserViewModel>();
            CreateMap<Brand, BrandViewModel>();
            CreateMap<BrandViewModel, Brand>();
        }
    }
}
