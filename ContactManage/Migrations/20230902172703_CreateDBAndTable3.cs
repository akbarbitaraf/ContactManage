using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManage.Migrations
{
    /// <inheritdoc />
    public partial class CreateDBAndTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_ContactTypes_ContactTypesId",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_contacts_ContactTypesId",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "ContactTypesId",
                table: "contacts");

            migrationBuilder.AlterColumn<int>(
                name: "ContactType_ID",
                table: "contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ContactType_ID",
                table: "contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ContactTypesId",
                table: "contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_contacts_ContactTypesId",
                table: "contacts",
                column: "ContactTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_ContactTypes_ContactTypesId",
                table: "contacts",
                column: "ContactTypesId",
                principalTable: "ContactTypes",
                principalColumn: "Id");
        }
    }
}
