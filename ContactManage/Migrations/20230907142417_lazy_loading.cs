using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManage.Migrations
{
    /// <inheritdoc />
    public partial class lazyloading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactsId",
                table: "ContactTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypes_ContactsId",
                table: "ContactTypes",
                column: "ContactsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactTypes_contacts_ContactsId",
                table: "ContactTypes",
                column: "ContactsId",
                principalTable: "contacts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactTypes_contacts_ContactsId",
                table: "ContactTypes");

            migrationBuilder.DropIndex(
                name: "IX_ContactTypes_ContactsId",
                table: "ContactTypes");

            migrationBuilder.DropColumn(
                name: "ContactsId",
                table: "ContactTypes");
        }
    }
}
