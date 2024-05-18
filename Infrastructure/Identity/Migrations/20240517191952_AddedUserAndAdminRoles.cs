using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserAndAdminRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "014016ff-ee35-40c2-97f8-6645f9b9b61c", null, "User", "USER" },
                    { "ca2e46fb-1b65-43b0-b4a0-4d1af195fd25", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "014016ff-ee35-40c2-97f8-6645f9b9b61c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca2e46fb-1b65-43b0-b4a0-4d1af195fd25");
        }
    }
}
