using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddQuartoReservasContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdQuarto",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdQuarto",
                table: "Reserva",
                column: "IdQuarto");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Quarto_IdQuarto",
                table: "Reserva",
                column: "IdQuarto",
                principalTable: "Quarto",
                principalColumn: "IdQuarto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Quarto_IdQuarto",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IdQuarto",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IdQuarto",
                table: "Reserva");
        }
    }
}
