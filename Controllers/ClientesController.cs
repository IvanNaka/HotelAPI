using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hotel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotelAPI.Controllers
{

    [Route("[controller]")]
    public class ClientesController : Controller
    {
        private readonly HotelContext _context;

        public ClientesController(HotelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  IActionResult GetClientes()
        {
            using (var _context = new HotelContext()){
                List<Clientes> ListaClientes = _context.Clientes.ToList();
                return Ok(ListaClientes);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetClientesPorId(int id)
        {
            using (var _context = new HotelContext()){
                var cliente =  _context.Clientes.Find(id);

                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado!");
                }

                return Ok(cliente);
            }

        }

        [HttpPost]
        public IActionResult PostClientes([FromBody] Clientes cliente)
        {
            using (var _context = new HotelContext()){
                try{
                    _context.Clientes.Add(cliente);
                    _context.SaveChanges();
                }catch{
                    return BadRequest("Erro ao cadastrar cliente!");
                }
                return Ok(cliente);
            }
        }

        [HttpPut]
        public IActionResult PutClientes(Clientes cliente)
        {
            using (var _context = new HotelContext()){
                var clienteBanco =  _context.Clientes.Find(cliente.IdCliente);

                if (clienteBanco == null)
                {
                    return NotFound("Cliente não encontrado!");
                }
                try{
                    _context.Entry(clienteBanco).CurrentValues.SetValues(cliente);
                    _context.SaveChanges();
                    return Ok(cliente);
                }catch{
                    return BadRequest("Erro ao cadastrar cliente!");
                }
            }
        }


        [HttpDelete]
        public IActionResult DeleteClientes(int id)
        {
            using (var _context = new HotelContext()){
                var clienteBanco =  _context.Clientes.Find(id);

                if (clienteBanco == null)
                {
                    return NotFound("Cliente não encontrado!");
                }
                try{
                    _context.Clientes.Remove(clienteBanco);
                    _context.SaveChanges();
                    return Ok();
                }catch{
                    return BadRequest("Erro ao deletar cliente!");
                }
            }
        }
    }
}