using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_GarageWebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addAplicationUserToCarRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "CarRecords",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "0b667fc3-6855-40fb-859a-779947f7c03f");

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationUserId",
                value: "0b667fc3-6855-40fb-859a-779947f7c03f");

            migrationBuilder.UpdateData(
                table: "CarRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationUserId",
                value: "0b667fc3-6855-40fb-859a-779947f7c03f");

            migrationBuilder.CreateIndex(
                name: "IX_CarRecords_ApplicationUserId",
                table: "CarRecords",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRecords_AspNetUsers_ApplicationUserId",
                table: "CarRecords",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRecords_AspNetUsers_ApplicationUserId",
                table: "CarRecords");

            migrationBuilder.DropIndex(
                name: "IX_CarRecords_ApplicationUserId",
                table: "CarRecords");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "CarRecords");
        }
    }
}
