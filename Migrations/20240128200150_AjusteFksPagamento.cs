using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjusteFksPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoDeConsumiveis_Pagamento_IdPagamento",
                table: "PagamentoDeConsumiveis");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoDeServicos_Pagamento_IdPagamento",
                table: "PagamentoDeServicos");

            migrationBuilder.RenameColumn(
                name: "IdPagamento",
                table: "PagamentoDeServicos",
                newName: "IdReserva");

            migrationBuilder.RenameIndex(
                name: "IX_PagamentoDeServicos_IdPagamento",
                table: "PagamentoDeServicos",
                newName: "IX_PagamentoDeServicos_IdReserva");

            migrationBuilder.RenameColumn(
                name: "IdPagamento",
                table: "PagamentoDeConsumiveis",
                newName: "IdReserva");

            migrationBuilder.RenameIndex(
                name: "IX_PagamentoDeConsumiveis_IdPagamento",
                table: "PagamentoDeConsumiveis",
                newName: "IX_PagamentoDeConsumiveis_IdReserva");

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoDeConsumiveis_Reserva_IdReserva",
                table: "PagamentoDeConsumiveis",
                column: "IdReserva",
                principalTable: "Reserva",
                principalColumn: "IdReserva");

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoDeServicos_Reserva_IdReserva",
                table: "PagamentoDeServicos",
                column: "IdReserva",
                principalTable: "Reserva",
                principalColumn: "IdReserva");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoDeConsumiveis_Reserva_IdReserva",
                table: "PagamentoDeConsumiveis");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoDeServicos_Reserva_IdReserva",
                table: "PagamentoDeServicos");

            migrationBuilder.RenameColumn(
                name: "IdReserva",
                table: "PagamentoDeServicos",
                newName: "IdPagamento");

            migrationBuilder.RenameIndex(
                name: "IX_PagamentoDeServicos_IdReserva",
                table: "PagamentoDeServicos",
                newName: "IX_PagamentoDeServicos_IdPagamento");

            migrationBuilder.RenameColumn(
                name: "IdReserva",
                table: "PagamentoDeConsumiveis",
                newName: "IdPagamento");

            migrationBuilder.RenameIndex(
                name: "IX_PagamentoDeConsumiveis_IdReserva",
                table: "PagamentoDeConsumiveis",
                newName: "IX_PagamentoDeConsumiveis_IdPagamento");

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoDeConsumiveis_Pagamento_IdPagamento",
                table: "PagamentoDeConsumiveis",
                column: "IdPagamento",
                principalTable: "Pagamento",
                principalColumn: "IdPagamento");

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoDeServicos_Pagamento_IdPagamento",
                table: "PagamentoDeServicos",
                column: "IdPagamento",
                principalTable: "Pagamento",
                principalColumn: "IdPagamento");
        }
    }
}
