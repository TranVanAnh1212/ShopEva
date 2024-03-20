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
            CreateMap<ProductProductCategory, ProductProductCategoryViewModel>();
            CreateMap<Sys_Status, StatusViewModel>();
        }
    }
}
