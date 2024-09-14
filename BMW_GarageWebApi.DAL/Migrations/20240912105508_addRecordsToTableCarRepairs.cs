using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BMW_GarageWebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addRecordsToTableCarRepairs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CarRepairs");

            migrationBuilder.InsertData(
                table: "CarRepairs",
                columns: new[] { "Id", "PriceFrom", "PriceTo", "TypeOfCarRepair" },
                values: new object[,]
                {
                    { 1, 700m, 900m, "Діагностика кондиціонера" },
                    { 2, 400m, 1000m, "Діагностика ДВЗ" },
                    { 3, 800m, 1000m, "Комп'ютерна діагностика" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CarRepairs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
