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
            CreateMap<Sys_Status, StatusViewModel>();
        }
    }
}
