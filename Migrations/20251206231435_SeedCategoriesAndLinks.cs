using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace linkHomeApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoriesAndLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "News" },
                    { 2, "Social" },
                    { 3, "Education" },
                    { 4, "Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "CategoryId", "Label", "Pinned", "Url" },
                values: new object[,]
                {
                    { 1, 1, "CNN", true, "https://www.cnn.com" },
                    { 2, 1, "BBC", false, "https://www.bbc.com" },
                    { 3, 1, "Reuters", false, "https://www.reuters.com" },
                    { 4, 2, "Facebook", true, "https://www.facebook.com" },
                    { 5, 2, "Twitter", false, "https://www.twitter.com" },
                    { 6, 2, "Instagram", false, "https://www.instagram.com" },
                    { 7, 3, "Khan Academy", false, "https://www.khanacademy.org" },
                    { 8, 3, "Coursera", false, "https://www.coursera.org" },
                    { 9, 3, "edX", false, "https://www.edx.org" },
                    { 10, 4, "YouTube", true, "https://www.youtube.com" },
                    { 11, 4, "Netflix", false, "https://www.netflix.com" },
                    { 12, 4, "Spotify", false, "https://www.spotify.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
