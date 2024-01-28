using System.ComponentModel.DataAnnotations;
public class TipoQuarto
{
    [Key]
    public required int IdTipoQuarto { get; set; }

    [StringLength(128)]
    public required string DescricaoQuarto { get; set; }
}