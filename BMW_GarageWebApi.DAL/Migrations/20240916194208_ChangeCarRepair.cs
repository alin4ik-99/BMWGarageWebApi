using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_GarageWebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCarRepair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceFrom",
                table: "CarRepairs");

            migrationBuilder.DropColumn(
                name: "PriceTo",
                table: "CarRepairs");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceMax",
                table: "CarRepairs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceMin",
                table: "CarRepairs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PriceMax", "PriceMin" },
                values: new object[] { 900m, 700m });

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PriceMax", "PriceMin" },
                values: new object[] { 1000m, 400m });

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PriceMax", "PriceMin" },
                values: new object[] { 1000m, 800m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceMax",
                table: "CarRepairs");

            migrationBuilder.DropColumn(
                name: "PriceMin",
                table: "CarRepairs");

            migrationBuilder.AddColumn<double>(
                name: "PriceFrom",
                table: "CarRepairs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceTo",
                table: "CarRepairs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PriceFrom", "PriceTo" },
                values: new object[] { 700.0, 900.0 });

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PriceFrom", "PriceTo" },
                values: new object[] { 400.0, 1000.0 });

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PriceFrom", "PriceTo" },
                values: new object[] { 800.0, 1000.0 });
        }
    }
}
