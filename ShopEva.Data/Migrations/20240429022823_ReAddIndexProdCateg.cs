using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopEva.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReAddIndexProdCateg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                schema: "public",
                table: "ProductCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                schema: "public",
                table: "ProductCategories");
        }
    }
}
