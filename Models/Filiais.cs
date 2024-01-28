using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Filial
{
    [Key]
    public int IdFilial { get; set; }

    [StringLength(64)]
    public string NomeFilial { get; set; }

    public short NumeroQuartos { get; set; }

    public short QtdEstrelas { get; set; }

    [ForeignKey("Endereco")]
    public int IdEndereco { get; set; }
    public Endereco Endereco { get; set; }
}
