using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Consumiveis
{
    [Key]
    public int IdConsumiveis { get; set; }

    [StringLength(128)]
    public string DescricaoConsumo { get; set; }
    public double ValorConsumo { get; set; }

    [ForeignKey("Filial")]
    public int IdFilial { get; set; }
    public Filial Filial { get; set; }
}