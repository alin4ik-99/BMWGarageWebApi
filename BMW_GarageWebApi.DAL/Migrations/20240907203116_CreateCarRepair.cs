using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_GarageWebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateCarRepair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCarRecord",
                table: "CarRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CarRepairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfCarRepair = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceTo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRepairs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusCarRecord",
                value: "NotConfirmed");

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusCarRecord",
                value: "NotConfirmed");

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusCarRecord",
                value: "NotConfirmed");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: "Male");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRepairs");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "StatusCarRecord",
                table: "CarRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusCarRecord",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusCarRecord",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusCarRecord",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: 1);
        }
    }
}
