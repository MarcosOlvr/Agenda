using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAgendaIdToCompromissos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgendaId",
                table: "Compromissos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Compromissos_AgendaId",
                table: "Compromissos",
                column: "AgendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compromissos_Agendas_AgendaId",
                table: "Compromissos",
                column: "AgendaId",
                principalTable: "Agendas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compromissos_Agendas_AgendaId",
                table: "Compromissos");

            migrationBuilder.DropIndex(
                name: "IX_Compromissos_AgendaId",
                table: "Compromissos");

            migrationBuilder.DropColumn(
                name: "AgendaId",
                table: "Compromissos");
        }
    }
}
