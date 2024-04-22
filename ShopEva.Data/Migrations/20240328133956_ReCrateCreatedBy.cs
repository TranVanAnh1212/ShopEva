using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopEva.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReCrateCreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "public",
                table: "Sys_Status",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "public",
                table: "Sys_Status",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "public",
                table: "SupportOnlines",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "public",
                table: "SupportOnlines",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "public",
                table: "Slides",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "public",
                table: "Slides",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "public",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "public",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "public",
                table: "ProductCategories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "public",
                table: "ProductCategories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "public",
                table: "Posts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "public",
                table: "Posts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "public",
                table: "PostCategories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "public",
                table: "PostCategories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "public",
                table: "Pages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "public",
                table: "Pages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "public",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "public",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "public",
                table: "Feedbacks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "public",
                table: "Feedbacks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "public",
                table: "Brands",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "public",
                table: "Brands",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Sys_Status");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "public",
                table: "Sys_Status");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "SupportOnlines");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "public",
                table: "SupportOnlines");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "public",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "public",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "public",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "public",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "public",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "public",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "public",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "public",
                table: "Brands");
        }
    }
}
