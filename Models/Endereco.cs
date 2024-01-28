using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Endereco
{
    [Key]
    public int IdEndereco { get; set; }

    [StringLength(64)]
    public string Pais { get; set; }

    [StringLength(64)]
    public string Estado { get; set; }

    [StringLength(64)]
    public string Cidade { get; set; }

    [StringLength(64)]
    public string Rua { get; set; }

    [StringLength(64)]
    public short Numero { get; set; }

    [StringLength(64)]
    public string? Complemento { get; set; }


    [ForeignKey("Cliente")]
    public int? IdCliente { get; set; }
    public Clientes? Cliente { get; set; }
}