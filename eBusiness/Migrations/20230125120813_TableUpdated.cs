using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBusiness.Migrations
{
    public partial class TableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Icons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Icons_MemberId",
                table: "Icons",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Icons_Members_MemberId",
                table: "Icons",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icons_Members_MemberId",
                table: "Icons");

            migrationBuilder.DropIndex(
                name: "IX_Icons_MemberId",
                table: "Icons");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Icons");
        }
    }
}
