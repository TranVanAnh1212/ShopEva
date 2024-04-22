using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopEva.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCreatedByProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("1ca76560-4705-4c28-b75e-32964f7e8a7b"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("1fbbeb4d-8971-4665-b6c4-8b79a660c75d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("4697b76f-29cd-4aa5-b27e-2f6ac719e611"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("5067a87a-ac19-426d-970a-4ca876556d52"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("61703895-bb33-406c-97c0-5679644be942"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("7a25cfa7-71f6-466d-8518-098f23315c50"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("8058d42b-767b-4fd4-a529-27a837a9b01e"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("89b1b492-18e8-4343-a6fe-d294df11831a"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("9253aa1b-6f73-41b1-882c-fe9ec40f7345"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("945e725e-0763-467a-83f9-ac4036094082"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("97c60401-325a-4196-af27-4c96bb161a40"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("fe806a50-0f20-460b-987b-fdc74ba4b18d"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                schema: "public",
                table: "Brands",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Logo", "MetaDescription", "MetaKeyWord", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("1ca76560-4705-4c28-b75e-32964f7e8a7b"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8665), null, null, null, null, null, "Bom sister", 1 },
                    { new Guid("1fbbeb4d-8971-4665-b6c4-8b79a660c75d"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8674), null, null, null, null, null, "Jody", 1 },
                    { new Guid("4697b76f-29cd-4aa5-b27e-2f6ac719e611"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8659), null, null, null, null, null, "Cocosin", 1 },
                    { new Guid("5067a87a-ac19-426d-970a-4ca876556d52"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8667), null, null, null, null, null, "Ivy moda", 1 },
                    { new Guid("61703895-bb33-406c-97c0-5679644be942"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8672), null, null, null, null, null, "Sunfly", 1 },
                    { new Guid("7a25cfa7-71f6-466d-8518-098f23315c50"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8679), null, null, null, null, null, "Vingo", 1 },
                    { new Guid("8058d42b-767b-4fd4-a529-27a837a9b01e"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8685), null, null, null, null, null, "EVA DE EVA", 1 },
                    { new Guid("89b1b492-18e8-4343-a6fe-d294df11831a"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8657), null, null, null, null, null, "Loire", 1 },
                    { new Guid("9253aa1b-6f73-41b1-882c-fe9ec40f7345"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8640), null, null, null, null, null, "Canifa", 1 },
                    { new Guid("945e725e-0763-467a-83f9-ac4036094082"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8662), null, null, null, null, null, "Gumac", 1 },
                    { new Guid("97c60401-325a-4196-af27-4c96bb161a40"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8669), null, null, null, null, null, "Just bra", 1 },
                    { new Guid("fe806a50-0f20-460b-987b-fdc74ba4b18d"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8682), null, null, null, null, null, "Elise", 1 }
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 0,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8294));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8297));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 23, 19, 14, 26, 960, DateTimeKind.Local).AddTicks(8298));
        }
    }
}
