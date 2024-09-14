using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_GarageWebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class decimaltodouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PriceTo",
                table: "CarRepairs",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PriceFrom",
                table: "CarRepairs",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PriceTo",
                table: "CarRepairs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceFrom",
                table: "CarRepairs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PriceFrom", "PriceTo" },
                values: new object[] { 700m, 900m });

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PriceFrom", "PriceTo" },
                values: new object[] { 400m, 1000m });

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PriceFrom", "PriceTo" },
                values: new object[] { 800m, 1000m });
        }
    }
}
