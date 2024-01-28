using Hotel;
using Microsoft.AspNetCore.Mvc;


namespace WebApi
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Reserva reserva)
        {
            using (var _context = new HotelContext())
            {
                _context.Reserva.Add(reserva);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Reserva> Get()
        {
            using (var _context = new HotelContext())
            {
                return _context.Reserva.ToList();
            }
        }

    }
}