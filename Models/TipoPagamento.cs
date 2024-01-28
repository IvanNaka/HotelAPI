using System.ComponentModel.DataAnnotations;
public class TipoPagamento
{
    [Key]
    public int IdTipoPagamento { get; set; }

    [StringLength(64)]
    public required string DescricaoTipoPag { get; set; }
}