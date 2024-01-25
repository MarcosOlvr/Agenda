using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArrumandoCoisas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_AspNetUsers_UserId",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_UserId",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Agendas");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Agendas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Agendas");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Agendas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_UserId",
                table: "Agendas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_AspNetUsers_UserId",
                table: "Agendas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
