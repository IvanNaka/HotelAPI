using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Quarto
{
    [Key]
    public int IdQuarto { get; set; }
    public short NumeroQuarto { get; set; }
    public short CapacidadeMaxima { get; set; }
    public bool? Adaptavel { get; set; }
    public double ValorQuarto { get; set; }

    [ForeignKey("Filial")]
    public int IdFilial { get; set; }
    public Filial Filial { get; set; }

    [ForeignKey("TipoQuarto")]
    public int IdTipoQuarto { get; set; }
    public TipoQuarto TipoQuarto { get; set; }

    public ICollection<Reserva>? Reserva { get; set; }
}