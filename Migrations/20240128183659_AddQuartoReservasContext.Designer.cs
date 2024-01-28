﻿// <auto-generated />
using System;
using Hotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelAPI.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20240128183659_AddQuartoReservasContext")]
    partial class AddQuartoReservasContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clientes", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("EmailCliente")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("TelefoneCliente")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Consumiveis", b =>
                {
                    b.Property<int>("IdConsumiveis")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdConsumiveis"));

                    b.Property<string>("DescricaoConsumo")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("IdFilial")
                        .HasColumnType("int");

                    b.Property<double>("ValorConsumo")
                        .HasColumnType("float");

                    b.HasKey("IdConsumiveis");

                    b.HasIndex("IdFilial");

                    b.ToTable("Consumiveis");
                });

            modelBuilder.Entity("Endereco", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEndereco"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<short>("Numero")
                        .HasMaxLength(64)
                        .HasColumnType("smallint");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("IdEndereco");

                    b.HasIndex("IdCliente");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Filial", b =>
                {
                    b.Property<int>("IdFilial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFilial"));

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<string>("NomeFilial")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<short>("NumeroQuartos")
                        .HasColumnType("smallint");

                    b.Property<short>("QtdEstrelas")
                        .HasColumnType("smallint");

                    b.HasKey("IdFilial");

                    b.HasIndex("IdEndereco");

                    b.ToTable("Filial");
                });

            modelBuilder.Entity("Funcionario", b =>
                {
                    b.Property<int>("IdFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFuncionario"));

                    b.Property<int>("IdFilial")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoFuncionario")
                        .HasColumnType("int");

                    b.Property<string>("NomeFuncionario")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("IdFuncionario");

                    b.HasIndex("IdFilial");

                    b.HasIndex("IdTipoFuncionario");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("Pagamento", b =>
                {
                    b.Property<int>("IdPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPagamento"));

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdReserva")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPagamento")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotalPag")
                        .HasColumnType("float");

                    b.HasKey("IdPagamento");

                    b.HasIndex("IdReserva");

                    b.HasIndex("IdTipoPagamento");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("PagamentoDeConsumiveis", b =>
                {
                    b.Property<int>("IdPagamentoConsumivel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPagamentoConsumivel"));

                    b.Property<int>("IdConsumiveis")
                        .HasColumnType("int");

                    b.Property<int>("IdPagamento")
                        .HasColumnType("int");

                    b.Property<int>("QtdConsumiveis")
                        .HasColumnType("int");

                    b.Property<bool>("RoomService")
                        .HasColumnType("bit");

                    b.HasKey("IdPagamentoConsumivel");

                    b.HasIndex("IdConsumiveis");

                    b.HasIndex("IdPagamento");

                    b.ToTable("PagamentoDeConsumiveis");
                });

            modelBuilder.Entity("PagamentoDeServicos", b =>
                {
                    b.Property<int>("IdPagamentoServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPagamentoServico"));

                    b.Property<int>("IdPagamento")
                        .HasColumnType("int");

                    b.Property<int>("IdServicos")
                        .HasColumnType("int");

                    b.HasKey("IdPagamentoServico");

                    b.HasIndex("IdPagamento");

                    b.HasIndex("IdServicos");

                    b.ToTable("PagamentoDeServicos");
                });

            modelBuilder.Entity("Quarto", b =>
                {
                    b.Property<int>("IdQuarto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdQuarto"));

                    b.Property<bool?>("Adaptavel")
                        .HasColumnType("bit");

                    b.Property<short>("CapacidadeMaxima")
                        .HasColumnType("smallint");

                    b.Property<int>("IdFilial")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoQuarto")
                        .HasColumnType("int");

                    b.Property<short>("NumeroQuarto")
                        .HasColumnType("smallint");

                    b.Property<double>("ValorQuarto")
                        .HasColumnType("float");

                    b.HasKey("IdQuarto");

                    b.HasIndex("IdFilial");

                    b.HasIndex("IdTipoQuarto");

                    b.ToTable("Quarto");
                });

            modelBuilder.Entity("Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserva"));

                    b.Property<bool?>("Cancelado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("IdQuarto")
                        .HasColumnType("int");

                    b.Property<short>("NumPessoas")
                        .HasColumnType("smallint");

                    b.HasKey("IdReserva");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdFuncionario");

                    b.HasIndex("IdQuarto");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("Servicos", b =>
                {
                    b.Property<int>("IdServicos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServicos"));

                    b.Property<string>("DescricaoServico")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("IdFilial")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorServico")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdServicos");

                    b.HasIndex("IdFilial");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("TipoFuncionario", b =>
                {
                    b.Property<int>("IdTipoFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoFuncionario"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoFuncionario");

                    b.ToTable("TipoFuncionario");
                });

            modelBuilder.Entity("TipoPagamento", b =>
                {
                    b.Property<int>("IdTipoPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoPagamento"));

                    b.Property<string>("DescricaoTipoPag")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("IdTipoPagamento");

                    b.ToTable("TipoPagamento");
                });

            modelBuilder.Entity("TipoQuarto", b =>
                {
                    b.Property<int>("IdTipoQuarto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoQuarto"));

                    b.Property<string>("DescricaoQuarto")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("IdTipoQuarto");

                    b.ToTable("TipoQuarto");
                });

            modelBuilder.Entity("Consumiveis", b =>
                {
                    b.HasOne("Filial", "Filial")
                        .WithMany()
                        .HasForeignKey("IdFilial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filial");
                });

            modelBuilder.Entity("Endereco", b =>
                {
                    b.HasOne("Clientes", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Filial", b =>
                {
                    b.HasOne("Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Funcionario", b =>
                {
                    b.HasOne("Filial", "Filial")
                        .WithMany()
                        .HasForeignKey("IdFilial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TipoFuncionario", "TipoFuncionario")
                        .WithMany()
                        .HasForeignKey("IdTipoFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filial");

                    b.Navigation("TipoFuncionario");
                });

            modelBuilder.Entity("Pagamento", b =>
                {
                    b.HasOne("Reserva", "Reserva")
                        .WithMany()
                        .HasForeignKey("IdReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TipoPagamento", "TipoPagamento")
                        .WithMany()
                        .HasForeignKey("IdTipoPagamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");

                    b.Navigation("TipoPagamento");
                });

            modelBuilder.Entity("PagamentoDeConsumiveis", b =>
                {
                    b.HasOne("Consumiveis", "Consumiveis")
                        .WithMany()
                        .HasForeignKey("IdConsumiveis")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pagamento", "Pagamento")
                        .WithMany("PagamentoDeConsumiveis")
                        .HasForeignKey("IdPagamento")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Consumiveis");

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("PagamentoDeServicos", b =>
                {
                    b.HasOne("Pagamento", "Pagamento")
                        .WithMany("PagamentoDeServicos")
                        .HasForeignKey("IdPagamento")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Servicos", "Servicos")
                        .WithMany()
                        .HasForeignKey("IdServicos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pagamento");

                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("Quarto", b =>
                {
                    b.HasOne("Filial", "Filial")
                        .WithMany()
                        .HasForeignKey("IdFilial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TipoQuarto", "TipoQuarto")
                        .WithMany()
                        .HasForeignKey("IdTipoQuarto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filial");

                    b.Navigation("TipoQuarto");
                });

            modelBuilder.Entity("Reserva", b =>
                {
                    b.HasOne("Clientes", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("IdFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quarto", "Quarto")
                        .WithMany("Reserva")
                        .HasForeignKey("IdQuarto")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");

                    b.Navigation("Quarto");
                });

            modelBuilder.Entity("Servicos", b =>
                {
                    b.HasOne("Filial", "Filial")
                        .WithMany()
                        .HasForeignKey("IdFilial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filial");
                });

            modelBuilder.Entity("Pagamento", b =>
                {
                    b.Navigation("PagamentoDeConsumiveis");

                    b.Navigation("PagamentoDeServicos");
                });

            modelBuilder.Entity("Quarto", b =>
                {
                    b.Navigation("Reserva");
                });
#pragma warning restore 612, 618
        }
    }
}
