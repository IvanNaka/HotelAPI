using Hotel;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ServicosController : Controller
    {
        [HttpGet]
        public  IActionResult GetServicos()
        {
            using (var _context = new HotelContext()){
                List<Servicos> ListaServicos = _context.Servicos.ToList();
                return Ok(ListaServicos);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetServicoPorId(int id)
        {
            using (var _context = new HotelContext()){
                var servicos =  _context.Servicos.Find(id);

                if (servicos == null)
                {
                    return NotFound("Serviço não encontrado!");
                }

                return Ok(servicos);
            }

        }

        [HttpPost]
        public IActionResult CadastroServico([FromBody] Servicos servicos)
        {
            using (var _context = new HotelContext()){
                try{
                    _context.Servicos.Add(servicos);
                    _context.SaveChanges();
                }catch{
                    return BadRequest("Erro ao cadastrar servico!");
                }
                return Ok(servicos);
            }
        }

        [HttpPost("addservico")]
        public IActionResult AddConsumivelReserva([FromBody] ServicosCadastro servicos)
        {
            using (var _context = new HotelContext()){
                try{
                    servicos.constructServicoPagamento();
                }catch{
                    return BadRequest("Erro ao cadastrar consumiveis!");
                }
                return Ok(servicos);
            }
        }

        [HttpPut]
        public IActionResult EditConsumiveis(Consumiveis consumivel)
        {
            using (var _context = new HotelContext()){
                var consumivelObj =  _context.Consumiveis.Find(consumivel.IdConsumiveis);

                if (consumivelObj == null)
                {
                    return NotFound("Cliente não encontrado!");
                }
                try{
                    _context.Entry(consumivelObj).CurrentValues.SetValues(consumivel);
                    _context.SaveChanges();
                    return Ok(consumivel);
                }catch{
                    return BadRequest("Erro ao editar consumível!");
                }
            }
        }


        [HttpDelete]
        public IActionResult DeleteConsumivel(int id)
        {
            using (var _context = new HotelContext()){
                var consumivelObj =  _context.Consumiveis.Find(id);

                if (consumivelObj == null)
                {
                    return NotFound("Consumível não encontrado!");
                }
                try{
                    _context.Consumiveis.Remove(consumivelObj);
                    _context.SaveChanges();
                    return Ok();
                }catch{
                    return BadRequest("Erro ao deletar consumível!");
                }
            }
        }
    }
}