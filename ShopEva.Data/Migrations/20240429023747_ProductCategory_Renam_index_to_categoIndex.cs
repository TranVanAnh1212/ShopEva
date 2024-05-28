using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopEva.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductCategory_Renam_index_to_categoIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Index",
                schema: "public",
                table: "ProductCategories",
                newName: "CategIndex");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategIndex",
                schema: "public",
                table: "ProductCategories",
                newName: "Index");
        }
    }
}
