using ShopEva.Data.ViewModels;
using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Services.Extention
{
    public static class EntityExtention
    {
        public static void ProductCategoryMap(this ProductCategory entity, ProductCategoryViewModel vm)
        {
            entity.ID = vm.ID;
            entity.Name = vm.Name;
            entity.Description = vm.Description;
            entity.Alias = vm.Alias;
            entity.ParentID = vm.ParentID;
            entity.Image = vm.Image;
            entity.DisplayOrder = vm.DisplayOrder;
            entity.HomeFlag = vm.HomeFlag;
            entity.CreatedDate = vm.CreatedDate;
            entity.CreatedBy = vm.CreatedBy;
            entity.ModifiedDate = vm.ModifiedDate;
            entity.ModifiedBy = vm.ModifiedBy;
            entity.MetaKeyWord = vm.MetaKeyWord;
            entity.MetaDescription = vm.MetaDescription;
            entity.Status = vm.Status;
        }

        public static void ProductMap(this Product entity, ProductViewModel vm)
        {
            entity.ID = vm.ID;
            entity.Name = vm.Name;
            entity.Description = vm.Description;
            entity.Alias = vm.Alias;
            entity.Image = vm.Image;
            entity.HomeFlag = vm.HomeFlag;
            entity.Contents = vm.Contents;
            entity.MoreImage = vm.MoreImage;
            entity.HotFlag = vm.HotFlag;
            entity.ViewCount = vm.ViewCount;
            entity.BuyCount = vm.BuyCount;
            entity.Quantity = vm.Quantity;
            entity.Price = vm.Price;
            entity.PromotionPrice = vm.PromotionPrice;
            entity.ReviewCount = vm.ReviewCount;
            entity.Tags = vm.Tags;
            entity.CreatedDate = vm.CreatedDate;
            entity.CreatedBy = vm.CreatedBy;
            entity.ModifiedDate = vm.ModifiedDate;
            entity.ModifiedBy = vm.ModifiedBy;
            entity.MetaKeyWord = vm.MetaKeyWord;
            entity.MetaDescription = vm.MetaDescription;
            entity.Status = vm.Status;
        }

        public static void ProductDetailMap(this ProductDetail entity, ProductDetailViewModel vm)
        {
            entity.ID = vm.ID;
            entity.ProductID = vm.ProductID;
            entity.Colors = vm.Colors;
            entity.Sizes = vm.Sizes;
            entity.Rating = vm.Rating;
            entity.BrandID = vm.BrandID;
            entity.Material = vm.Material;
            entity.Other_Info = vm.Other_Info;
        }

        public static void ProductProductCategoryMap(this ProductProductCategory entity, ProductProductCategoryViewModel vm)
        {
            entity.CategoryID = vm.CategoryID;
            entity.ProductID = vm.ProductID;
        }
    }
}
