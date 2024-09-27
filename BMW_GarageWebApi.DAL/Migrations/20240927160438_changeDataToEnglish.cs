using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_GarageWebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeDataToEnglish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRecords_AspNetUsers_ApplicationUserId",
                table: "CarRecords");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "CarRecords",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "FullName" },
                values: new object[] { "Replacing spark plugs", "Davenko Serhii Viktorovych" });

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "FullName" },
                values: new object[] { "Ignition system diagnostics", "Kovalenko Serhiy Yervandovych" });

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "FullName" },
                values: new object[] { "Body geometry correction", "Divanek Igor Serhiyovich" });

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TypeOfCarRepair",
                value: "Diagnostics of the air conditioner");

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 2,
                column: "TypeOfCarRepair",
                value: "Diagnostics of the Far Eastern Branch");

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 3,
                column: "TypeOfCarRepair",
                value: "Comparative Diagnostics");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FullName", "Notes", "Position" },
                values: new object[] { "Zhezherya Serhiy Viktorovich", "Completion of the use of diagnostic tools and facilities for the manifestation and solution of a wide range of automotive problems", "mechanic" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FullName", "Notes", "Position" },
                values: new object[] { "Rubakov Serhiy Erandovich", "Direct communication of navicciations, detailed explanations of repair and technical maintenance of clients", "mechanic" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FullName", "Notes", "Position" },
                values: new object[] { "Gladkyi Igor Serhiyovich", "The ability to resolve issues quickly and efficiently, ensuring minimal downtime for customers", "mechanic" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarRecords_AspNetUsers_ApplicationUserId",
                table: "CarRecords",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRecords_AspNetUsers_ApplicationUserId",
                table: "CarRecords");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "CarRecords",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "FullName" },
                values: new object[] { "Замена свечей зажигания", "Давенко Сергій Вікторович" });

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "FullName" },
                values: new object[] { "Диагностика системы зажигания", "Коваленко Сергій Єрвандович" });

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "FullName" },
                values: new object[] { "Исправление геометрии кузова", "Діванек Ігор Сергійович" });

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TypeOfCarRepair",
                value: "Діагностика кондиціонера");

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 2,
                column: "TypeOfCarRepair",
                value: "Діагностика ДВЗ");

            migrationBuilder.UpdateData(
                table: "CarRepairs",
                keyColumn: "Id",
                keyValue: 3,
                column: "TypeOfCarRepair",
                value: "Комп'ютерна діагностика");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FullName", "Notes", "Position" },
                values: new object[] { "Жежеря Сергій Вікторович", "Досконале володіння діагностичними інструментами та обладнанням для виявлення та вирішення широкого кола автомобільних проблем", "Автомеханік" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FullName", "Notes", "Position" },
                values: new object[] { "Рубаков Сергій Єрвандович", "Відмінні комунікативні навички, надання чітких пояснень щодо ремонту та технічного обслуговування клієнтам", "Автомеханік" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FullName", "Notes", "Position" },
                values: new object[] { "Гладкий Ігор Сергійович", "здатність швидко й ефективно усувати проблеми, забезпечуючи мінімальний час простою для клієнтів", "Автомеханік" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarRecords_AspNetUsers_ApplicationUserId",
                table: "CarRecords",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
