using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Pagamento
{
    [Key]
    public int IdPagamento { get; set; }
    public DateTime DataPagamento { get; set; }
    public double ValorTotalPag { get; set; }

    [ForeignKey("Reserva")]
    public int IdReserva { get; set; }
    public Reserva Reserva { get; set; }

    [ForeignKey("TipoPagamento")]
    public int IdTipoPagamento { get; set; }
    public TipoPagamento TipoPagamento { get; set; }
}