using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddItCanBeNullUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_User_UserId",
                schema: "RealEstateSchema",
                table: "Property");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "RealEstateSchema",
                table: "Property",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_User_UserId",
                schema: "RealEstateSchema",
                table: "Property",
                column: "UserId",
                principalSchema: "RealEstateSchema",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_User_UserId",
                schema: "RealEstateSchema",
                table: "Property");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "RealEstateSchema",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_User_UserId",
                schema: "RealEstateSchema",
                table: "Property",
                column: "UserId",
                principalSchema: "RealEstateSchema",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
