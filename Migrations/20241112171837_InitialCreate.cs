using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrialApis.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d"), "Moderate" },
                    { new Guid("d2f1e8a2-3c4b-4a1e-9f5b-1a2b3c4d5e6f"), "Easy" },
                    { new Guid("f1e2d3c4-b5a6-7e8f-9d0c-1b2a3c4d5e6f"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d"), "AKL", "Auckland", "https://example.com/auckland.jpg" },
                    { new Guid("d2f1e8a2-3c4b-4a1e-9f5b-1a2b3c4d5e6f"), "NL", "Northland", "https://example.com/northland.jpg" },
                    { new Guid("f1e2d3c4-b5a6-7e8f-9d0c-1b2a3c4d5e6f"), "WKO", "Waikato", "https://example.com/waikato.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d2f1e8a2-3c4b-4a1e-9f5b-1a2b3c4d5e6f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f1e2d3c4-b5a6-7e8f-9d0c-1b2a3c4d5e6f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d2f1e8a2-3c4b-4a1e-9f5b-1a2b3c4d5e6f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f1e2d3c4-b5a6-7e8f-9d0c-1b2a3c4d5e6f"));
        }
    }
}
