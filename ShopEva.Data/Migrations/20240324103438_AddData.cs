using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopEva.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("14da3c63-6340-45fd-8810-e17bfe10923f"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("417f794c-d438-42d3-8332-a494b9aae521"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("4af59ebe-89fc-448c-a2a9-86e5cc0a0848"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("6977c38c-faa7-488b-9235-1c4b4803ce2c"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("75fcdeb1-4bd2-4f06-ae58-7fcbe28cac83"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("761fadeb-c0dd-48f8-b757-683f3b625134"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("7ab26843-39fd-48f8-a5b6-e1a69b4053ee"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("7ec30b94-c336-4b45-8c34-10f64800193f"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("9bd14431-4f3d-4979-a8eb-3fcbc3b2f827"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("bb6c9e33-36e8-4582-8e7a-e6d3d851fec9"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("be285245-4fba-4092-acfd-f99aa7b622b1"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("d7b77e64-566d-4975-ba92-327b5c1f7d27"));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 0,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 24, 10, 34, 37, 934, DateTimeKind.Utc).AddTicks(6495));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 24, 10, 34, 37, 934, DateTimeKind.Utc).AddTicks(6508));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 24, 10, 34, 37, 934, DateTimeKind.Utc).AddTicks(6510));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 24, 10, 34, 37, 934, DateTimeKind.Utc).AddTicks(6512));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "Brands",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Logo", "MetaDescription", "MetaKeyWord", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("14da3c63-6340-45fd-8810-e17bfe10923f"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3350), null, null, null, null, null, "Cocosin", 1 },
                    { new Guid("417f794c-d438-42d3-8332-a494b9aae521"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3354), null, null, null, null, null, "Gumac", 1 },
                    { new Guid("4af59ebe-89fc-448c-a2a9-86e5cc0a0848"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3383), null, null, null, null, null, "Vingo", 1 },
                    { new Guid("6977c38c-faa7-488b-9235-1c4b4803ce2c"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3379), null, null, null, null, null, "Jody", 1 },
                    { new Guid("75fcdeb1-4bd2-4f06-ae58-7fcbe28cac83"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3363), null, null, null, null, null, "Just bra", 1 },
                    { new Guid("761fadeb-c0dd-48f8-b757-683f3b625134"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3375), null, null, null, null, null, "Sunfly", 1 },
                    { new Guid("7ab26843-39fd-48f8-a5b6-e1a69b4053ee"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3340), null, null, null, null, null, "Canifa", 1 },
                    { new Guid("7ec30b94-c336-4b45-8c34-10f64800193f"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3386), null, null, null, null, null, "Elise", 1 },
                    { new Guid("9bd14431-4f3d-4979-a8eb-3fcbc3b2f827"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3357), null, null, null, null, null, "Bom sister", 1 },
                    { new Guid("bb6c9e33-36e8-4582-8e7a-e6d3d851fec9"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3360), null, null, null, null, null, "Ivy moda", 1 },
                    { new Guid("be285245-4fba-4092-acfd-f99aa7b622b1"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3347), null, null, null, null, null, "Loire", 1 },
                    { new Guid("d7b77e64-566d-4975-ba92-327b5c1f7d27"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3389), null, null, null, null, null, "EVA DE EVA", 1 }
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 0,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3074));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3096));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 24, 5, 35, 25, 85, DateTimeKind.Utc).AddTicks(3101));
        }
    }
}
