using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Reserva
{
    [Key]
    public int IdReserva { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
    public bool? Cancelado { get; set; }
    public short NumPessoas { get; set; }

    [ForeignKey("Cliente")]
    public int IdCliente { get; set; }
    public Clientes Cliente { get; set; }

    [ForeignKey("Funcionario")]
    public int IdFuncionario { get; set; }
    public Funcionario Funcionario { get; set; }
}
