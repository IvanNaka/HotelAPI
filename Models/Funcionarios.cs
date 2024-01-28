using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Funcionario
{
    [Key]
    public int IdFuncionario { get; set; }

    [StringLength(128)]
    public string NomeFuncionario { get; set; }
    
    [ForeignKey("Filial")]
    public int IdFilial { get; set; }
    public Filial Filial { get; set; }

    [ForeignKey("TipoFuncionario")]
    public int IdTipoFuncionario { get; set; }
    public TipoFuncionario TipoFuncionario { get; set; }
}