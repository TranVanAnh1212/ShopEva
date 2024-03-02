﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShopEva.Data.Contexts;

#nullable disable

namespace ShopEva.Data.Migrations
{
    [DbContext(typeof(ShopEvaDbContext))]
    [Migration("20240301095957_AllowNotNullSomeProperty")]
    partial class AllowNotNullSomeProperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ShopEva.Models.Model.Brand", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Logo")
                        .HasColumnType("character varying");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Brands", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Error", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StackTrace")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Errors", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Feedback", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Images")
                        .HasColumnType("text");

                    b.Property<int>("Likes")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ParentID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Videos")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Feedbacks", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Footer", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Contents")
                        .HasMaxLength(550)
                        .HasColumnType("character varying(550)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("character varying(550)");

                    b.HasKey("ID");

                    b.ToTable("Footers", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Menu", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("integer");

                    b.Property<Guid>("GroupID")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(501)
                        .HasColumnType("character varying(501)");

                    b.Property<bool>("Static")
                        .HasColumnType("boolean");

                    b.Property<string>("Target")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.ToTable("Menus", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.MenuGroup", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("character varying(550)");

                    b.HasKey("ID");

                    b.ToTable("MenuGroup", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Order", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(501)
                        .HasColumnType("character varying(501)");

                    b.Property<string>("CustomerEmail")
                        .HasMaxLength(501)
                        .HasColumnType("character varying(501)");

                    b.Property<string>("CustomerMessage")
                        .HasMaxLength(501)
                        .HasColumnType("character varying(501)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(501)
                        .HasColumnType("character varying(501)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Orders", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderID")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uuid")
                        .HasColumnOrder(2);

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Page", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Contents")
                        .HasMaxLength(501)
                        .HasColumnType("character varying(501)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(501)
                        .HasColumnType("character varying(501)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Pages", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Post", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid?>("CategoryID")
                        .HasColumnType("uuid");

                    b.Property<string>("Contents")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<bool>("HomeFlag")
                        .HasColumnType("boolean");

                    b.Property<bool>("HotFlag")
                        .HasColumnType("boolean");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(501)
                        .HasColumnType("character varying(501)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("ViewCount")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Posts", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.PostCategory", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Alias")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int?>("DisplayOrder")
                        .HasColumnType("integer");

                    b.Property<bool>("HomeFlag")
                        .HasColumnType("boolean");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(501)
                        .HasColumnType("character varying(501)");

                    b.Property<Guid?>("ParentID")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("PostCategories", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.PostTag", b =>
                {
                    b.Property<Guid>("PostID")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<string>("TagID")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnOrder(2);

                    b.HasKey("PostID", "TagID");

                    b.HasIndex("TagID");

                    b.ToTable("PostTags", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("BuyCount")
                        .HasColumnType("integer");

                    b.Property<Guid?>("CategoryID")
                        .HasColumnType("uuid");

                    b.Property<string>("Contents")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<bool>("HomeFlag")
                        .HasColumnType("boolean");

                    b.Property<bool>("HotFlag")
                        .HasColumnType("boolean");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MoreImage")
                        .HasColumnType("xml");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(501)
                        .HasColumnType("character varying(501)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("PromotionPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("ReviewCount")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ViewCount")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.ProductCategory", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Alias")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int?>("DisplayOrder")
                        .HasColumnType("integer");

                    b.Property<bool>("HomeFlag")
                        .HasColumnType("boolean");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(501)
                        .HasColumnType("character varying(501)");

                    b.Property<Guid?>("ParentID")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("ProductCategories", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.ProductDetail", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<string>("Colors")
                        .HasColumnType("text");

                    b.Property<string>("Material")
                        .HasColumnType("text");

                    b.Property<string>("Other_Info")
                        .HasColumnType("text");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("Sizes")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ProductDetails", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.ProductTag", b =>
                {
                    b.Property<Guid>("ProductID")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<string>("TagID")
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnOrder(2);

                    b.HasKey("ProductID", "TagID");

                    b.HasIndex("TagID");

                    b.ToTable("ProductTags", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Slide", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(501)
                        .HasColumnType("character varying(501)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Url")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("ID");

                    b.ToTable("Slides", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.SupportOnline", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Department")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Facebook")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Instagram")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Skype")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Twitter")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("ID");

                    b.ToTable("SupportOnlines", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Sys_Status", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Status_Of")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Sys_Status", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.SystemConfig", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<int>("ValueInt")
                        .HasColumnType("integer");

                    b.Property<string>("ValueStr")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("ID");

                    b.ToTable("SystemConfigs", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Tag", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.ToTable("Tags", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.VisitorStatistic", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("IPAddress")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("VisitedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.ToTable("VisitorStatistic", "public");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Menu", b =>
                {
                    b.HasOne("ShopEva.Models.Model.MenuGroup", "MenuGroup")
                        .WithMany("Menu")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuGroup");
                });

            modelBuilder.Entity("ShopEva.Models.Model.OrderDetail", b =>
                {
                    b.HasOne("ShopEva.Models.Model.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopEva.Models.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Post", b =>
                {
                    b.HasOne("ShopEva.Models.Model.PostCategory", "PostCategory")
                        .WithMany("Post")
                        .HasForeignKey("CategoryID");

                    b.Navigation("PostCategory");
                });

            modelBuilder.Entity("ShopEva.Models.Model.PostTag", b =>
                {
                    b.HasOne("ShopEva.Models.Model.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopEva.Models.Model.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Product", b =>
                {
                    b.HasOne("ShopEva.Models.Model.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("ShopEva.Models.Model.ProductTag", b =>
                {
                    b.HasOne("ShopEva.Models.Model.Product", "Product")
                        .WithMany("ProductTags")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopEva.Models.Model.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("ShopEva.Models.Model.MenuGroup", b =>
                {
                    b.Navigation("Menu");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Post", b =>
                {
                    b.Navigation("PostTags");
                });

            modelBuilder.Entity("ShopEva.Models.Model.PostCategory", b =>
                {
                    b.Navigation("Post");
                });

            modelBuilder.Entity("ShopEva.Models.Model.Product", b =>
                {
                    b.Navigation("ProductTags");
                });
#pragma warning restore 612, 618
        }
    }
}
