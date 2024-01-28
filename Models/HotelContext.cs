using Microsoft.EntityFrameworkCore;

namespace Hotel
{
    public class HotelContext : DbContext{
        public DbSet<Clientes> Clientes {get; set;} = null!;
        public DbSet<Consumiveis> Consumiveis {get; set;} = null!;
        public DbSet<Endereco> Endereco {get; set;} = null!;
        public DbSet<Filial> Filial {get; set;} = null!;
        public DbSet<Funcionario> Funcionario {get; set;} = null!;
        public DbSet<Pagamento> Pagamento {get; set;} = null!;
        public DbSet<Quarto> Quarto {get; set;} = null!;
        public DbSet<Reserva> Reserva {get; set;} = null!;
        public DbSet<Servicos> Servicos {get; set;} = null!;
        public DbSet<TipoFuncionario> TipoFuncionario {get; set;} = null!;
        public DbSet<TipoPagamento> TipoPagamento {get; set;} = null!;
        public DbSet<TipoQuarto> TipoQuarto {get; set;} = null!;
        public DbSet<PagamentoDeServicos> PagamentoDeServicos {get; set;} = null!;
        public DbSet<PagamentoDeConsumiveis> PagamentoDeConsumiveis {get; set;} = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Ivan\SQLEXPRESS;Database=HotelApi;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PagamentoDeConsumiveis>()
                .HasOne(pc => pc.Pagamento)
                .WithMany(p => p.PagamentoDeConsumiveis)
                .HasForeignKey(pc => pc.IdPagamento)
               .OnDelete(DeleteBehavior.NoAction);  
            modelBuilder.Entity<PagamentoDeServicos>()
                .HasOne(pc => pc.Pagamento)
                .WithMany(p => p.PagamentoDeServicos)
                .HasForeignKey(pc => pc.IdPagamento)
                .OnDelete(DeleteBehavior.NoAction);  
            modelBuilder.Entity<Endereco>().Property(m => m.IdCliente).IsRequired(false);            
        }
    }
}