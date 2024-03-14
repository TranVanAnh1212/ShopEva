using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopEva.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyAvatarInAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                schema: "public",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                schema: "public",
                table: "Users");
        }
    }
}
