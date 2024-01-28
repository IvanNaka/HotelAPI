using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class PagamentoDeServicos
{
    [Key]
    public int IdPagamentoServico { get; set; }

    [ForeignKey("Pagamento")]
    public int IdPagamento { get; set; }
    public Pagamento Pagamento { get; set; }

    [ForeignKey("Servicos")]
    public int IdServicos { get; set; }
    public Servicos Servicos { get; set; }
}