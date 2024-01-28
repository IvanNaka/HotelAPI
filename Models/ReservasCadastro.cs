using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OpenApi.Models;
public class ReservaCadastro
{
    public DateTime CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
    public short NumPessoas { get; set; }
    public int IdCliente {get; set;}
    public int IdFuncionario {get; set;}
    public int IdQuarto {get; set;}
    public Reserva? constructReserva(){

        using (var _context = new Hotel.HotelContext()){
                var cliente =  _context.Clientes.Find(this.IdCliente);

                if (cliente == null)
                {
                    throw new Exception("Cliente não encontrado!");
                }
                var funcionario =  _context.Funcionario.Find(this.IdFuncionario);

                if (funcionario == null)
                {
                    throw new Exception("Funcionário não encontrado!");
                }

                var quarto =  _context.Quarto.Find(this.IdQuarto);

                if (quarto == null)
                {
                    throw new Exception("Quarto não encontrado!");
                }

                Reserva reserva = new Reserva();
                reserva.CheckIn = this.CheckIn;
                reserva.Cancelado = false;
                reserva.NumPessoas = this.NumPessoas;
                reserva.IdCliente = this.IdCliente;
                reserva.Cliente = cliente;
                reserva.IdFuncionario = this.IdFuncionario;
                reserva.Funcionario = funcionario;
                reserva.IdQuarto = this.IdQuarto;
                reserva.Quarto = quarto;
                _context.Reserva.Add(reserva);
                _context.SaveChanges();
                return reserva;
            }
    }
}
