using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Repetition.Data.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_Owner_OwnerId",
                table: "Dog");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Dog",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_Owner_OwnerId",
                table: "Dog",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_Owner_OwnerId",
                table: "Dog");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Dog",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_Owner_OwnerId",
                table: "Dog",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
