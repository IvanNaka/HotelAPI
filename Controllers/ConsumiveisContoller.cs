using Hotel;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ConsumiveisController : Controller
    {
        [HttpGet]
        public  IActionResult GetConsumiveis()
        {
            using (var _context = new HotelContext()){
                List<Consumiveis> ListaConsumiveis = _context.Consumiveis.ToList();
                return Ok(ListaConsumiveis);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetConsumivelPorId(int id)
        {
            using (var _context = new HotelContext()){
                var consumivel =  _context.Consumiveis.Find(id);

                if (consumivel == null)
                {
                    return NotFound("Consumivel não encontrado!");
                }

                return Ok(consumivel);
            }

        }

        [HttpPost]
        public IActionResult CadastroConsumivel([FromBody] Consumiveis consumivel)
        {
            using (var _context = new HotelContext()){
                try{
                    _context.Consumiveis.Add(consumivel);
                    _context.SaveChanges();
                }catch{
                    return BadRequest("Erro ao cadastrar consumiveis!");
                }
                return Ok(consumivel);
            }
        }

        [HttpPost("addconsumivel")]
        public IActionResult AddConsumivelReserva([FromBody] ConsumivelCadastro consumivel)
        {
            using (var _context = new HotelContext()){
                try{
                    consumivel.constructConsumivelPagamento();
                }catch{
                    return BadRequest("Erro ao cadastrar consumiveis!");
                }
                return Ok(consumivel);
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