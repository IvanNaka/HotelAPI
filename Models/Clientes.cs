using System.ComponentModel.DataAnnotations;
public class Clientes
{
    [Key]
    public int IdCliente { get; set; }
    
    [StringLength(64)]
    public string NomeCliente { get; set; }

    [StringLength(64)]
    public string Nacionalidade { get; set; }

    [StringLength(128)]
    public string EmailCliente { get; set; }
    
    [StringLength(32)]
    public string TelefoneCliente { get; set; }
}