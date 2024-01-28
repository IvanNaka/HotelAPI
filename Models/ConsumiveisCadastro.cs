using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OpenApi.Models;
public class ConsumivelCadastro
{
    public int IdConsumiveis { get; set; }
    public int IdReserva { get; set; }
    public int QtdConsumiveis { get; set; }
    public bool RoomService { get; set; }
    public PagamentoDeConsumiveis? constructConsumivelPagamento(){

        using (var _context = new Hotel.HotelContext()){
            var consumivel =  _context.Consumiveis.Find(this.IdConsumiveis);
            if (consumivel == null)
            {
                throw new Exception("Consumível não encontrado!");
            }
            var reserva =  _context.Reserva.Find(this.IdReserva);
            if (reserva == null)
            {
                throw new Exception("Funcionário não encontrado!");
            }
           
            PagamentoDeConsumiveis pagconsumivel = new PagamentoDeConsumiveis();
            pagconsumivel.IdReserva = this.IdReserva;
            pagconsumivel.Reserva = reserva;
            pagconsumivel.IdConsumiveis = this.IdReserva;
            pagconsumivel.Consumiveis = consumivel;
            pagconsumivel.QtdConsumiveis = this.QtdConsumiveis;
            pagconsumivel.RoomService = this.RoomService;
            _context.PagamentoDeConsumiveis.Add(pagconsumivel);
            _context.SaveChanges();
            return pagconsumivel;
        }
    }
}
