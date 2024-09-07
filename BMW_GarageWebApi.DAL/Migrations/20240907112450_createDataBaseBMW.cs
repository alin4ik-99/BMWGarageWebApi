using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BMW_GarageWebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class createDataBaseBMW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfHiring = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "DateOfHiring", "Email", "FullName", "Gender", "ImageUrl", "Notes", "PhoneNumber", "Position" },
                values: new object[,]
                {
                    { 1, new DateOnly(1998, 6, 16), new DateOnly(2021, 2, 11), "sergizezeria147@gmail.com", "Жежеря Сергій Вікторович", 0, "", "Досконале володіння діагностичними інструментами та обладнанням для виявлення та вирішення широкого кола автомобільних проблем", "+48 456 346 641", "Автомеханік" },
                    { 2, new DateOnly(1991, 5, 15), new DateOnly(2021, 2, 11), "rub4iksergo@gmail.com", "Рубаков Сергій Єрвандович", 0, "", "Відмінні комунікативні навички, надання чітких пояснень щодо ремонту та технічного обслуговування клієнтам", "+48 116 287 743", "Автомеханік" },
                    { 3, new DateOnly(1998, 6, 11), new DateOnly(2021, 2, 12), "gladkoua@gmail.com", "Гладкий Ігор Сергійович", 0, "", "здатність швидко й ефективно усувати проблеми, забезпечуючи мінімальний час простою для клієнтів", "+48 688 966 121", "Автомеханік" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
