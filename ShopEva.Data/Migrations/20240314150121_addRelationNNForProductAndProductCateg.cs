using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopEva.Data.Migrations
{
    /// <inheritdoc />
    public partial class addRelationNNForProductAndProductCateg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryID",
                schema: "public",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryID",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Brand",
                schema: "public",
                table: "ProductDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                schema: "public",
                table: "Products",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BrandID",
                schema: "public",
                table: "ProductDetails",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductProductCategory",
                schema: "public",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductCategory", x => new { x.CategoryID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_ProductProductCategory_ProductCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "public",
                        principalTable: "ProductCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductCategory_Products_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_BrandID",
                schema: "public",
                table: "ProductDetails",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductID",
                schema: "public",
                table: "ProductDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductCategory_ProductID",
                schema: "public",
                table: "ProductProductCategory",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Brands_BrandID",
                schema: "public",
                table: "ProductDetails",
                column: "BrandID",
                principalSchema: "public",
                principalTable: "Brands",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Products_ProductID",
                schema: "public",
                table: "ProductDetails",
                column: "ProductID",
                principalSchema: "public",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Brands_BrandID",
                schema: "public",
                table: "ProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Products_ProductID",
                schema: "public",
                table: "ProductDetails");

            migrationBuilder.DropTable(
                name: "ProductProductCategory",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_BrandID",
                schema: "public",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_ProductID",
                schema: "public",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Image2",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandID",
                schema: "public",
                table: "ProductDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                schema: "public",
                table: "Products",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryID",
                schema: "public",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                schema: "public",
                table: "ProductDetails",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                schema: "public",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryID",
                schema: "public",
                table: "Products",
                column: "CategoryID",
                principalSchema: "public",
                principalTable: "ProductCategories",
                principalColumn: "ID");
        }
    }
}
