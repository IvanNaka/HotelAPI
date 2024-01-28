using System.ComponentModel.DataAnnotations;
public class TipoFuncionario
{
    [Key]
    public int IdTipoFuncionario { get; set; }
    public string Descricao { get; set; }
}
