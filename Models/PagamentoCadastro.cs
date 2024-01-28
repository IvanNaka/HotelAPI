using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OpenApi.Models;
public class PagamentoCadastro
{
    public DateTime DataPagamento { get; set; }
    private double vlrTotal { get; set; }
    public int IdReserva { get; set; }
    public int IdTipoPagamento {get; set;}
    public Pagamento? construcPagamento(){

        using (var _context = new Hotel.HotelContext()){
                var reserva =  _context.Reserva.Find(this.IdReserva);

                if (reserva == null)
                {
                    throw new Exception("Reserva não encontrada!");
                }
                var tipoPagamento =  _context.TipoPagamento.Find(this.IdTipoPagamento);

                if (tipoPagamento == null)
                {
                    throw new Exception("Tipo de pagamento inválido!");
                }

                List<PagamentoDeServicos> ListaServico = _context.PagamentoDeServicos.ToList();
                foreach(PagamentoDeServicos servico in ListaServico){
                    this.vlrTotal +=  Convert.ToDouble(_context.Servicos.Find(servico.IdServicos).ValorServico);
                }

                List<PagamentoDeConsumiveis> ListaConsumiveis = _context.PagamentoDeConsumiveis.ToList();
                foreach(PagamentoDeConsumiveis consumivel in ListaConsumiveis){
                    Consumiveis consumivelObj = _context.Consumiveis.Find(consumivel.IdConsumiveis);
                    double vlrConsumo = consumivelObj.ValorConsumo;
                    double taxaRoomService = 1.10;
                    if (consumivel.RoomService == true){
                        vlrConsumo = vlrConsumo*taxaRoomService;
                    }
                    this.vlrTotal += vlrConsumo;
                }

                reserva.CheckOut = DateTime.Now;
            

                TimeSpan? diferencaDias = reserva.CheckOut - reserva.CheckIn;

                //int qtdDias = diferencaDias.HasValue ? diferencaDias.Value.Days : 0;
                int qtdDias = 1;

                Quarto quartoObj = _context.Quarto.Find(reserva.IdQuarto);

                double vlrDiaria = reserva.Quarto.ValorQuarto * qtdDias;

                if (reserva.NumPessoas > quartoObj.CapacidadeMaxima)
                    vlrDiaria = vlrDiaria * 1.25;
                this.vlrTotal += vlrDiaria;



                Pagamento pagamento = new Pagamento();
                pagamento.DataPagamento = this.DataPagamento;
                pagamento.ValorTotalPag = this.vlrTotal;
                pagamento.IdReserva = this.IdReserva;
                pagamento.Reserva = reserva;
                pagamento.IdTipoPagamento = this.IdTipoPagamento;
                pagamento.TipoPagamento = tipoPagamento;
                _context.Pagamento.Add(pagamento);
                _context.SaveChanges();
                return pagamento;
            }
    }
    static public double? getValorTotalPagamento (int IdReserva){
        using (var _context = new Hotel.HotelContext()){
            double vlrTotal = 0.0;
            var reserva =  _context.Reserva.Find(IdReserva);
            if (reserva == null)
            {
                throw new Exception("Reserva não encontrada!");
            }
            List<PagamentoDeServicos> ListaServico = _context.PagamentoDeServicos.ToList();
            foreach(PagamentoDeServicos servico in ListaServico){
                vlrTotal +=  Convert.ToDouble(_context.Servicos.Find(servico.IdServicos).ValorServico);
            }
            List<PagamentoDeConsumiveis> ListaConsumiveis = _context.PagamentoDeConsumiveis.ToList();
            foreach(PagamentoDeConsumiveis consumivel in ListaConsumiveis){
                Consumiveis consumivelObj = _context.Consumiveis.Find(consumivel.IdConsumiveis);
                double vlrConsumo = consumivelObj.ValorConsumo;
                double taxaRoomService = 1.10;
                if (consumivel.RoomService == true){
                    vlrConsumo = vlrConsumo*taxaRoomService;
                }
                vlrTotal += vlrConsumo;
            }
            reserva.CheckOut = DateTime.Now;
            TimeSpan? diferencaDias = reserva.CheckOut - reserva.CheckIn;
            int qtdDias = diferencaDias.HasValue ? diferencaDias.Value.Days : 0;
            Quarto quartoObj = _context.Quarto.Find(reserva.IdQuarto);
            double vlrDiaria = reserva.Quarto.ValorQuarto * qtdDias;
            if (reserva.NumPessoas > quartoObj.CapacidadeMaxima);
                vlrDiaria = vlrDiaria * 1.25;
            vlrTotal += vlrDiaria;
            return vlrTotal;
        }
    }
}
