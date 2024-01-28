using Hotel;
using Microsoft.AspNetCore.Mvc;


namespace WebApi
{
    [Route("[controller]")]
    [ApiController]
    public class Pagamentos : Controller
    {
        [HttpGet]
        public  IActionResult GetReservas()
        {
            using (var _context = new HotelContext()){
                List<Pagamento> ListaPagamentos = _context.Pagamento.ToList();
                return Ok(ListaPagamentos);
            }
        }

        [HttpPost]
        public IActionResult CadastroPagamento([FromBody] PagamentoCadastro pagamento)
        {
            using (var _context = new HotelContext()){
                try{
                    pagamento.construcPagamento();
                }catch(Exception e){
                    return BadRequest(e.Message);
                }
                return Ok(pagamento);
            }
        }

        [HttpGet("valorpagamento/{idReserva}")]
        public IActionResult getValorPagamento(int idReserva)
        {
            using (var _context = new HotelContext()){
                try{
                    double? vlrTotal =  PagamentoCadastro.getValorTotalPagamento(idReserva);
                    return Ok(vlrTotal);
                }catch(Exception e){
                    return BadRequest(e.Message);
                }
            }
        }

        [HttpPut]
        public IActionResult PutPagam(Pagamento pagamento)
        {
            using (var _context = new HotelContext()){
                var pagamentoBanco =  _context.Pagamento.Find(pagamento.IdPagamento);

                if (pagamentoBanco == null)
                {
                    return NotFound("Pagamento não encontrado!");
                }
                try{
                    _context.Entry(pagamentoBanco).CurrentValues.SetValues(pagamento);
                    _context.SaveChanges();
                    return Ok(pagamento);
                }catch{
                    return BadRequest("Erro ao editar pagmento!");
                }
            }
        }
    }
}