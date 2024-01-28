using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class PagamentoDeServicos
{
    [Key]
    public int IdPagamentoServico { get; set; }

    [ForeignKey("Reserva")]
    public int IdReserva { get; set; }
    public Reserva Reserva { get; set; }

    [ForeignKey("Servicos")]
    public int IdServicos { get; set; }
    public Servicos Servicos { get; set; }
}