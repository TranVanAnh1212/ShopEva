using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopEva.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Data_re : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "Brands",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Logo", "MetaDescription", "MetaKeyWord", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("01ef4796-8865-4f4a-bf7f-a4d79614276e"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8485), null, null, null, null, null, "Gumac", 1 },
                    { new Guid("0df75a93-c5a7-4ace-9339-dcbf7fae47ff"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8505), null, null, null, null, null, "Jody", 1 },
                    { new Guid("51b5bc09-9598-470b-b10b-ae349493e709"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8480), null, null, null, null, null, "Loire", 1 },
                    { new Guid("828f890d-30f6-4b3d-ba40-8991b4d68fa7"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8482), null, null, null, null, null, "Cocosin", 1 },
                    { new Guid("86d7b775-7204-4b00-b3cf-e8ae95b5ec3b"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8503), null, null, null, null, null, "Sunfly", 1 },
                    { new Guid("8b443765-2c51-4d00-ae6c-f8909f8c965a"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8499), null, null, null, null, null, "Ivy moda", 1 },
                    { new Guid("8dce7f5f-fa54-4e46-9547-97ed4426c55d"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8477), null, null, null, null, null, "Canifa", 1 },
                    { new Guid("936c59b9-3bd7-4101-90e9-ec42a1456b13"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8509), null, null, null, null, null, "Elise", 1 },
                    { new Guid("9a5ab217-a78e-476a-8d1a-c4b958fd75e7"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8511), null, null, null, null, null, "EVA DE EVA", 1 },
                    { new Guid("c4bedcf6-d90e-4f0f-89f4-4a90715de9a0"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8487), null, null, null, null, null, "Bom sister", 1 },
                    { new Guid("e3d6a1ea-af09-4d2c-98fd-e7d50642cab3"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8501), null, null, null, null, null, "Just bra", 1 },
                    { new Guid("e63eb8d7-240b-4e4a-9d65-62670c740070"), new Guid("8e1dce0d-5997-4834-b8ac-cbd4614e2b78"), new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8507), null, null, null, null, null, "Vingo", 1 }
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 0,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8297));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8312));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8319));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Sys_Status",
                keyColumn: "ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 24, 10, 45, 40, 515, DateTimeKind.Utc).AddTicks(8332));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("01ef4796-8865-4f4a-bf7f-a4d79614276e"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("0df75a93-c5a7-4ace-9339-dcbf7fae47ff"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("51b5bc09-9598-470b-b10b-ae349493e709"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("828f890d-30f6-4b3d-ba40-8991b4d68fa7"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("86d7b775-7204-4b00-b3cf-e8ae95b5ec3b"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("8b443765-2c51-4d00-ae6c-f8909f8c965a"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("8dce7f5f-fa54-4e46-9547-97ed4426c55d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("936c59b9-3bd7-4101-90e9-ec42a1456b13"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("9a5ab217-a78e-476a-8d1a-c4b958fd75e7"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("c4bedcf6-d90e-4f0f-89f4-4a90715de9a0"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("e3d6a1ea-af09-4d2c-98fd-e7d50642cab3"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Brands",
                keyColumn: "ID",
                keyValue: new Guid("e63eb8d7-240b-4e4a-9d65-62670c740070"));

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
    }
}
