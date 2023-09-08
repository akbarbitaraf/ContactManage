using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManage.Migrations
{
    /// <inheritdoc />
    public partial class lazyLoading3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_ContactTypes_ContactTypesId",
                table: "contacts");

            migrationBuilder.AlterColumn<int>(
                name: "ContactTypesId",
                table: "contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_ContactTypes_ContactTypesId",
                table: "contacts",
                column: "ContactTypesId",
                principalTable: "ContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_ContactTypes_ContactTypesId",
                table: "contacts");

            migrationBuilder.AlterColumn<int>(
                name: "ContactTypesId",
                table: "contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_ContactTypes_ContactTypesId",
                table: "contacts",
                column: "ContactTypesId",
                principalTable: "ContactTypes",
                principalColumn: "Id");
        }
    }
}
