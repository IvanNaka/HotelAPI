using Hotel;
using Microsoft.AspNetCore.Mvc;


namespace WebApi
{
    [Route("[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        [HttpGet]
        public  IActionResult GetReservas()
        {
            using (var _context = new HotelContext()){
                List<Reserva> ListaReserva = _context.Reserva.ToList();
                return Ok(ListaReserva);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetReservaPorId(int id)
        {
            using (var _context = new HotelContext()){
                var reserva =  _context.Reserva.Find(id);

                if (reserva == null)
                {
                    return NotFound("Reserva não encontrado!");
                }

                return Ok(reserva);
            }

        }

        [HttpPost]
        public IActionResult PostReserva([FromBody] ReservaCadastro reserva)
        {
            using (var _context = new HotelContext()){
                try{
                    reserva.constructReserva();
                }catch(Exception e){
                    return BadRequest(e.Message);
                }
                return Ok(reserva);
            }
        }

        [HttpPut]
        public IActionResult PutReserva(Reserva reserva)
        {
            using (var _context = new HotelContext()){
                var reservaBanco =  _context.Reserva.Find(reserva.IdReserva);

                if (reservaBanco == null)
                {
                    return NotFound("Reserva não encontrada!");
                }
                try{
                    _context.Entry(reservaBanco).CurrentValues.SetValues(reserva);
                    _context.SaveChanges();
                    return Ok(reserva);
                }catch{
                    return BadRequest("Erro ao editar reserva!");
                }
            }
        }


        [HttpDelete]
        public IActionResult CancelarReserva(int id)
        {
            using (var _context = new HotelContext()){
                var reservaBanco =  _context.Reserva.Find(id);

                if (reservaBanco == null)
                {
                    return NotFound("Reserva não encontrada!");
                }
                try{
                    bool cancelado = true;
                    reservaBanco.Cancelado = cancelado;
                    _context.SaveChanges();
                    return Ok(reservaBanco);
                }catch{
                    return BadRequest("Erro ao cancelar reserva!");
                }
            }
        }
    }
}