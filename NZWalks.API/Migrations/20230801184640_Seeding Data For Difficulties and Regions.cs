using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a0e7c01c-1f61-4a41-a905-041062a890d7"), "Medium" },
                    { new Guid("ae7585ee-52e5-4593-8d63-a09be9336e69"), "Easy" },
                    { new Guid("f2160189-3a1f-4dfc-b990-1ba76b940e90"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("4efa3513-a446-482e-ba64-9d64f7042f11"), "BOP", "Bay Of Plenty", "https://th.bing.com/th/id/R.883565d41f0c04c2a2ee9942dd960761?rik=8UquyV22VBq0xg&riu=http%3a%2f%2fwww.publicdomainpictures.net%2fpictures%2f190000%2fvelka%2fpixels.jpg&ehk=dMFEMOgh8NtNhHZ9UOFCKaxbo5TygoKsNwOiSYtoICU%3d&risl=&pid=ImgRaw&r=0" },
                    { new Guid("a52e7e5d-4352-4c9f-a012-c261b06563a1"), "STL", "Southland", "https://th.bing.com/th/id/R.883565d41f0c04c2a2ee9942dd960761?rik=8UquyV22VBq0xg&riu=http%3a%2f%2fwww.publicdomainpictures.net%2fpictures%2f190000%2fvelka%2fpixels.jpg&ehk=dMFEMOgh8NtNhHZ9UOFCKaxbo5TygoKsNwOiSYtoICU%3d&risl=&pid=ImgRaw&r=0" },
                    { new Guid("b0e2ed24-2aad-4c5f-9501-207e29bd3671"), "AKL", "Auckland", "https://th.bing.com/th/id/R.883565d41f0c04c2a2ee9942dd960761?rik=8UquyV22VBq0xg&riu=http%3a%2f%2fwww.publicdomainpictures.net%2fpictures%2f190000%2fvelka%2fpixels.jpg&ehk=dMFEMOgh8NtNhHZ9UOFCKaxbo5TygoKsNwOiSYtoICU%3d&risl=&pid=ImgRaw&r=0" },
                    { new Guid("ebd7664d-b99d-4361-93f6-a9feba3f7b93"), "NTL", "Northland", "https://th.bing.com/th/id/R.883565d41f0c04c2a2ee9942dd960761?rik=8UquyV22VBq0xg&riu=http%3a%2f%2fwww.publicdomainpictures.net%2fpictures%2f190000%2fvelka%2fpixels.jpg&ehk=dMFEMOgh8NtNhHZ9UOFCKaxbo5TygoKsNwOiSYtoICU%3d&risl=&pid=ImgRaw&r=0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a0e7c01c-1f61-4a41-a905-041062a890d7"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ae7585ee-52e5-4593-8d63-a09be9336e69"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f2160189-3a1f-4dfc-b990-1ba76b940e90"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4efa3513-a446-482e-ba64-9d64f7042f11"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a52e7e5d-4352-4c9f-a012-c261b06563a1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b0e2ed24-2aad-4c5f-9501-207e29bd3671"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ebd7664d-b99d-4361-93f6-a9feba3f7b93"));
        }
    }
}
