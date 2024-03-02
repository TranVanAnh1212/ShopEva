using ShopEva.Data.ViewModels;
using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Services.Extention
{
    public static class EntityExtention
    {
        public static void ProductCategoryMap(this ProductCategory pc, ProductCategoryViewModel pcVM)
        {
            pc.ID = pcVM.ID;
            pc.Name = pcVM.Name;
            pc.Description = pcVM.Description;
            pc.Alias = pcVM.Alias;
            pc.ParentID = pcVM.ParentID;
            pc.Image = pcVM.Image;
            pc.DisplayOrder = pcVM.DisplayOrder;
            pc.HomeFlag = pcVM.HomeFlag;
            pc.CreatedDate = pcVM.CreatedDate;
            pc.CreatedBy = pcVM.CreatedBy;
            pc.ModifiedDate = pcVM.ModifiedDate;
            pc.ModifiedBy = pcVM.ModifiedBy;
            pc.MetaKeyWord = pcVM.MetaKeyWord;
            pc.MetaDescription = pcVM.MetaDescription;
            pc.Status = pcVM.Status;
        }
    }
}
