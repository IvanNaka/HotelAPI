using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EmailCliente = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TelefoneCliente = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "TipoFuncionario",
                columns: table => new
                {
                    IdTipoFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoFuncionario", x => x.IdTipoFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagamento",
                columns: table => new
                {
                    IdTipoPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoTipoPag = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagamento", x => x.IdTipoPagamento);
                });

            migrationBuilder.CreateTable(
                name: "TipoQuarto",
                columns: table => new
                {
                    IdTipoQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoQuarto = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoQuarto", x => x.IdTipoQuarto);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pais = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Numero = table.Column<short>(type: "smallint", maxLength: 64, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.IdEndereco);
                    table.ForeignKey(
                        name: "FK_Endereco_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente");
                });

            migrationBuilder.CreateTable(
                name: "Filial",
                columns: table => new
                {
                    IdFilial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFilial = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    NumeroQuartos = table.Column<short>(type: "smallint", nullable: false),
                    QtdEstrelas = table.Column<short>(type: "smallint", nullable: false),
                    IdEndereco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filial", x => x.IdFilial);
                    table.ForeignKey(
                        name: "FK_Filial_Endereco_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Endereco",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumiveis",
                columns: table => new
                {
                    IdConsumiveis = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoConsumo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ValorConsumo = table.Column<double>(type: "float", nullable: false),
                    IdFilial = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumiveis", x => x.IdConsumiveis);
                    table.ForeignKey(
                        name: "FK_Consumiveis_Filial_IdFilial",
                        column: x => x.IdFilial,
                        principalTable: "Filial",
                        principalColumn: "IdFilial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IdFilial = table.Column<int>(type: "int", nullable: false),
                    IdTipoFuncionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.IdFuncionario);
                    table.ForeignKey(
                        name: "FK_Funcionario_Filial_IdFilial",
                        column: x => x.IdFilial,
                        principalTable: "Filial",
                        principalColumn: "IdFilial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionario_TipoFuncionario_IdTipoFuncionario",
                        column: x => x.IdTipoFuncionario,
                        principalTable: "TipoFuncionario",
                        principalColumn: "IdTipoFuncionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quarto",
                columns: table => new
                {
                    IdQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroQuarto = table.Column<short>(type: "smallint", nullable: false),
                    CapacidadeMaxima = table.Column<short>(type: "smallint", nullable: false),
                    Adaptavel = table.Column<bool>(type: "bit", nullable: true),
                    ValorQuarto = table.Column<double>(type: "float", nullable: false),
                    IdFilial = table.Column<int>(type: "int", nullable: false),
                    IdTipoQuarto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarto", x => x.IdQuarto);
                    table.ForeignKey(
                        name: "FK_Quarto_Filial_IdFilial",
                        column: x => x.IdFilial,
                        principalTable: "Filial",
                        principalColumn: "IdFilial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quarto_TipoQuarto_IdTipoQuarto",
                        column: x => x.IdTipoQuarto,
                        principalTable: "TipoQuarto",
                        principalColumn: "IdTipoQuarto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    IdServicos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoServico = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ValorServico = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdFilial = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.IdServicos);
                    table.ForeignKey(
                        name: "FK_Servicos_Filial_IdFilial",
                        column: x => x.IdFilial,
                        principalTable: "Filial",
                        principalColumn: "IdFilial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cancelado = table.Column<bool>(type: "bit", nullable: true),
                    NumPessoas = table.Column<short>(type: "smallint", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Funcionario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    IdPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotalPag = table.Column<double>(type: "float", nullable: false),
                    IdReserva = table.Column<int>(type: "int", nullable: false),
                    IdTipoPagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.IdPagamento);
                    table.ForeignKey(
                        name: "FK_Pagamento_Reserva_IdReserva",
                        column: x => x.IdReserva,
                        principalTable: "Reserva",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamento_TipoPagamento_IdTipoPagamento",
                        column: x => x.IdTipoPagamento,
                        principalTable: "TipoPagamento",
                        principalColumn: "IdTipoPagamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagamentoDeConsumiveis",
                columns: table => new
                {
                    IdPagamentoConsumivel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPagamento = table.Column<int>(type: "int", nullable: false),
                    IdConsumiveis = table.Column<int>(type: "int", nullable: false),
                    QtdConsumiveis = table.Column<int>(type: "int", nullable: false),
                    RoomService = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoDeConsumiveis", x => x.IdPagamentoConsumivel);
                    table.ForeignKey(
                        name: "FK_PagamentoDeConsumiveis_Consumiveis_IdConsumiveis",
                        column: x => x.IdConsumiveis,
                        principalTable: "Consumiveis",
                        principalColumn: "IdConsumiveis",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagamentoDeConsumiveis_Pagamento_IdPagamento",
                        column: x => x.IdPagamento,
                        principalTable: "Pagamento",
                        principalColumn: "IdPagamento");
                });

            migrationBuilder.CreateTable(
                name: "PagamentoDeServicos",
                columns: table => new
                {
                    IdPagamentoServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPagamento = table.Column<int>(type: "int", nullable: false),
                    IdServicos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoDeServicos", x => x.IdPagamentoServico);
                    table.ForeignKey(
                        name: "FK_PagamentoDeServicos_Pagamento_IdPagamento",
                        column: x => x.IdPagamento,
                        principalTable: "Pagamento",
                        principalColumn: "IdPagamento");
                    table.ForeignKey(
                        name: "FK_PagamentoDeServicos_Servicos_IdServicos",
                        column: x => x.IdServicos,
                        principalTable: "Servicos",
                        principalColumn: "IdServicos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consumiveis_IdFilial",
                table: "Consumiveis",
                column: "IdFilial");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdCliente",
                table: "Endereco",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Filial_IdEndereco",
                table: "Filial",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdFilial",
                table: "Funcionario",
                column: "IdFilial");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdTipoFuncionario",
                table: "Funcionario",
                column: "IdTipoFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_IdReserva",
                table: "Pagamento",
                column: "IdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_IdTipoPagamento",
                table: "Pagamento",
                column: "IdTipoPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoDeConsumiveis_IdConsumiveis",
                table: "PagamentoDeConsumiveis",
                column: "IdConsumiveis");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoDeConsumiveis_IdPagamento",
                table: "PagamentoDeConsumiveis",
                column: "IdPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoDeServicos_IdPagamento",
                table: "PagamentoDeServicos",
                column: "IdPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoDeServicos_IdServicos",
                table: "PagamentoDeServicos",
                column: "IdServicos");

            migrationBuilder.CreateIndex(
                name: "IX_Quarto_IdFilial",
                table: "Quarto",
                column: "IdFilial");

            migrationBuilder.CreateIndex(
                name: "IX_Quarto_IdTipoQuarto",
                table: "Quarto",
                column: "IdTipoQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdCliente",
                table: "Reserva",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdFuncionario",
                table: "Reserva",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_IdFilial",
                table: "Servicos",
                column: "IdFilial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagamentoDeConsumiveis");

            migrationBuilder.DropTable(
                name: "PagamentoDeServicos");

            migrationBuilder.DropTable(
                name: "Quarto");

            migrationBuilder.DropTable(
                name: "Consumiveis");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "TipoQuarto");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "TipoPagamento");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Filial");

            migrationBuilder.DropTable(
                name: "TipoFuncionario");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
