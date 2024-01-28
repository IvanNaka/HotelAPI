
public class ServicosCadastro
{
    public int IdServicos { get; set; }
    public int IdReserva { get; set; }
    public PagamentoDeServicos? constructServicoPagamento(){

        using (var _context = new Hotel.HotelContext()){
            var servico =  _context.Servicos.Find(this.IdServicos);
            if (servico == null)
            {
                throw new Exception("Consumível não encontrado!");
            }
            var reserva =  _context.Reserva.Find(this.IdReserva);
            if (reserva == null)
            {
                throw new Exception("Funcionário não encontrado!");
            }
           
            PagamentoDeServicos pagservicos = new PagamentoDeServicos();
            pagservicos.IdReserva = this.IdReserva;
            pagservicos.Reserva = reserva;
            pagservicos.IdServicos = this.IdServicos;
            pagservicos.Servicos = servico;
            _context.PagamentoDeServicos.Add(pagservicos);
            _context.SaveChanges();
            return pagservicos;
        }
    }
}
