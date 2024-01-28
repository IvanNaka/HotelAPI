using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Servicos
{
    [Key]
    public int IdServicos { get; set; }

    [StringLength(128)]
    public string DescricaoServico { get; set; }
    public decimal ValorServico { get; set; }

    [ForeignKey("Filial")]
    public int IdFilial { get; set; }
    public Filial Filial { get; set; }
}