using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManage.Migrations
{
    /// <inheritdoc />
    public partial class lazyLoading4 : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_contacts_ContactType_ID",
                table: "contacts",
                column: "ContactType_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_ContactTypes_ContactType_ID",
                table: "contacts",
                column: "ContactType_ID",
                principalTable: "ContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_ContactTypes_ContactType_ID",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_contacts_ContactType_ID",
                table: "contacts");

            migrationBuilder.AddColumn<int>(
                name: "ContactTypesId",
                table: "contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_contacts_ContactTypesId",
                table: "contacts",
                column: "ContactTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_ContactTypes_ContactTypesId",
                table: "contacts",
                column: "ContactTypesId",
                principalTable: "ContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
