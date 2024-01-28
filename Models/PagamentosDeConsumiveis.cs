using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class PagamentoDeConsumiveis
{
    [Key]
    public int IdPagamentoConsumivel { get; set; }
    
    [ForeignKey("Pagamento")]
    public int IdPagamento { get; set; }
    public Pagamento Pagamento { get; set; }
 
    [ForeignKey("Consumiveis")]
    public int IdConsumiveis { get; set; }
    public Consumiveis Consumiveis { get; set; }
    public int QtdConsumiveis { get; set; }
    public bool RoomService { get; set; }
}
