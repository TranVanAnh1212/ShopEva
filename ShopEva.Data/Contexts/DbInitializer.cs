using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Data.Contexts
{
    public class DbInitializer
    {
        public static void Initialize(ShopEvaDbContext context)
        {
            CreateBrandSample(context);
            CreateStatusSample(context);
            CreateProductCategorySample(context);
            CreateProductSample(context);
        }

        private static void CreateBrandSample(ShopEvaDbContext context)
        {
            if (context.Brands.Count() == 0)
            {
                List<Brand> brands = new List<Brand>
                {
                    new Brand() { ID = Guid.NewGuid(), Name = "Canifa", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
                    new Brand() { ID = Guid.NewGuid(), Name = "Loire", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
                    new Brand() { ID = Guid.NewGuid(), Name = "Cocosin", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
                    new Brand() { ID = Guid.NewGuid(), Name = "Gumac", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
                    new Brand() { ID = Guid.NewGuid(), Name = "Bom sister", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
                    new Brand() { ID = Guid.NewGuid(), Name = "Ivy moda", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
                    new Brand() { ID = Guid.NewGuid(), Name = "Just bra", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
                    new Brand() { ID = Guid.NewGuid(), Name = "Sunfly", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
                    new Brand() { ID = Guid.NewGuid(), Name = "Jody", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
                    new Brand() { ID = Guid.NewGuid(), Name = "Vingo", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
                    new Brand() { ID = Guid.NewGuid(), Name = "Elise", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
                    new Brand() { ID = Guid.NewGuid(), Name = "EVA DE EVA", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
                };
            }
        }

        private static void CreateFooterSample(ShopEvaDbContext context)
        {
            if (context.Footers.Count(x => x.ID == "footerTop1") == 0)
            {
                Footer footer = new Footer()
                {
                    ID = "footerTop1",
                    Name = "FooterTop1",
                    Contents = "",
                };

                context.Footers.Add(footer);
                context.SaveChanges();
            }
        }

        private static void CreateProductCategorySample(ShopEvaDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() {ID = Guid.NewGuid(), Name="Thời trang nam",Alias="thoi-trang-nam", CreatedDate=DateTime.Now, Status=1 },
                    new ProductCategory() {ID = Guid.NewGuid(), Name="Thời trang mẹ và bé",Alias="thoi-trang-me-va-be", CreatedDate=DateTime.Now, Status=1 },
                    new ProductCategory() {ID = Guid.NewGuid(), Name="Giày dép nữ",Alias="giay-dep-nu", CreatedDate=DateTime.Now, Status=1 },
                    new ProductCategory() {ID = Guid.NewGuid(), Name="Giày dép nam",Alias="giay-dep-nam", CreatedDate=DateTime.Now, Status=1 },
                    new ProductCategory() {ID = Guid.NewGuid(), Name="Túi ví nư",Alias="tui-vi-nu", CreatedDate=DateTime.Now, Status=1 }
                };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }

        private static void CreateProductSample(ShopEvaDbContext context)
        {
            if (context.Products.Count() == 0)
            {
                List<Product> listProd = new List<Product>()
                {
                    new Product() {
                        ID = Guid.NewGuid(),
                        Name="IPhone 15 Pro Max 258GB",
                        Alias="IPhone15, Apple, IPhone",
                        Price=35990000,
                        Quantity=165,
                        CreatedDate=DateTime.Now,
                        CreatedBy="TranVanAnh - Admin", },
                    new Product() {
                        ID = Guid.NewGuid(),
                        Name="Samsung galaxy",
                        Alias="samsung-galaxy, samsung",
                        Price=2990000,
                        Quantity=15,
                        CreatedDate=DateTime.Now,
                        CreatedBy="TranVanAnh - Admin", },
                    new Product() {
                        ID = Guid.NewGuid(),
                        Name="TV OSny",
                        Alias="TV, Sony, TVSony",
                        Price=12990000,
                        Quantity=165,
                        CreatedDate=DateTime.Now,
                        CreatedBy="TranVanAnh - Admin", },
                };
                context.Products.AddRange(listProd);
                context.SaveChanges();
            }

        }

        private static void CreateStatusSample(ShopEvaDbContext context)
        {
            if (context.Sys_Statuses.Count() == 0)
            {
                List<Sys_Status> sys_Statuses = new List<Sys_Status>()
                {
                    new Sys_Status { ID = 1, Name = "Sử dụng", Status_Of = 1, CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
                    new Sys_Status { ID = 2, Name = "Không sử dụng", Status_Of = 1,  CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
                    new Sys_Status { ID = 3, Name = "Chờ duyệt", Status_Of = 1, CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
                    new Sys_Status { ID = 0, Name = "Nháp", Status_Of = 1,  CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },

                    new Sys_Status { ID = 11, Name = "Chưa giao", Status_Of = 2, CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
                    new Sys_Status { ID = 12, Name = "Đang giao", Status_Of = 2,  CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
                    new Sys_Status { ID = 13, Name = "Đã giao", Status_Of = 2, CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
                    new Sys_Status { ID = 10, Name = "Hủy đơn", Status_Of = 2,  CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
                    new Sys_Status { ID = 14, Name = "Chờ xác nhận", Status_Of = 2,  CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
                };

                context.Sys_Statuses.AddRange(sys_Statuses);
                context.SaveChanges();
            }
        }
    }
}
