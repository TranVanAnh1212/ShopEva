using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopEva.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLatestLoginForAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("04bd559c-b93b-4969-8e23-f8cb7b54cefb"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("0831f2bd-ae92-43e5-b8d5-2a9c6e609be2"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("3a4bac5e-9110-4d23-bfea-a6decd285b1a"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("3ce9eb09-ad7d-4d95-9af5-bab6c9e1978f"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("4652dfdb-f553-4afc-8ad8-4d423e0dd82c"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("597946f7-de60-4238-b497-de9a07995866"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("70b2495b-1254-4115-a1f0-2596bf1c09b3"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("76965a40-647c-4328-b59b-390f6c0936f9"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("87c7b64b-3e80-45bb-80b1-b01ef6f3fc11"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("a37e0e02-d0a2-4f62-9e22-a9eb13555276"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("b7283e40-4ebb-48af-a755-e7eb429031fd"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("d1b81409-2b8a-4cf1-8c4e-72b946bb8b1f"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LatestLogin",
                schema: "public",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "LatestLogin",
                schema: "public",
                table: "Users");

            migrationBuilder.InsertData(
                schema: "public",
                table: "Brands",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Logo", "MetaDescription", "MetaKeyWord", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("04bd559c-b93b-4969-8e23-f8cb7b54cefb"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6297), null, null, null, null, null, "Bom sister", 1 },
                    { new Guid("0831f2bd-ae92-43e5-b8d5-2a9c6e609be2"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6310), null, null, null, null, null, "Jody", 1 },
                    { new Guid("3a4bac5e-9110-4d23-bfea-a6decd285b1a"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6302), null, null, null, null, null, "Just bra", 1 },
                    { new Guid("3ce9eb09-ad7d-4d95-9af5-bab6c9e1978f"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6286), null, null, null, null, null, "Canifa", 1 },
                    { new Guid("4652dfdb-f553-4afc-8ad8-4d423e0dd82c"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6317), null, null, null, null, null, "EVA DE EVA", 1 },
                    { new Guid("597946f7-de60-4238-b497-de9a07995866"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6305), null, null, null, null, null, "Sunfly", 1 },
                    { new Guid("70b2495b-1254-4115-a1f0-2596bf1c09b3"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6293), null, null, null, null, null, "Cocosin", 1 },
                    { new Guid("76965a40-647c-4328-b59b-390f6c0936f9"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6290), null, null, null, null, null, "Loire", 1 },
                    { new Guid("87c7b64b-3e80-45bb-80b1-b01ef6f3fc11"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6295), null, null, null, null, null, "Gumac", 1 },
                    { new Guid("a37e0e02-d0a2-4f62-9e22-a9eb13555276"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6315), null, null, null, null, null, "Elise", 1 },
                    { new Guid("b7283e40-4ebb-48af-a755-e7eb429031fd"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6312), null, null, null, null, null, "Vingo", 1 },
                    { new Guid("d1b81409-2b8a-4cf1-8c4e-72b946bb8b1f"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6300), null, null, null, null, null, "Ivy moda", 1 }
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 0,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6050));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 23, 13, 5, 57, 205, DateTimeKind.Utc).AddTicks(6068));
        }
    }
}
