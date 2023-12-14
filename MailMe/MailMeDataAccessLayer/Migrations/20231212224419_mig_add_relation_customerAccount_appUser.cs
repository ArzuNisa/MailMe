using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailMeDataAccessLayer.Migrations
{
    public partial class mig_add_relation_customerAccount_appUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "PersonalAccounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalAccounts_AppUserID",
                table: "PersonalAccounts",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalAccounts_AspNetUsers_AppUserID",
                table: "PersonalAccounts",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalAccounts_AspNetUsers_AppUserID",
                table: "PersonalAccounts");

            migrationBuilder.DropIndex(
                name: "IX_PersonalAccounts_AppUserID",
                table: "PersonalAccounts");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "PersonalAccounts");
        }
    }
}
