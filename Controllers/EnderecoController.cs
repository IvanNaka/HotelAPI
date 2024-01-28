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
    public class EnderecoController : Controller
    {

        [HttpGet]
        public IActionResult GetEndereco()
        {
            using (var _context = new HotelContext()){
                List<Endereco> ListaEnderecos = _context.Endereco.ToList();
                return Ok(ListaEnderecos);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetEndereco(int id)
        {
            using (var _context = new HotelContext()){
                var endereco =  _context.Endereco.Find(id);

                if (endereco == null)
                {
                    return NotFound("Endereço não encontrado!");
                }

                return Ok(endereco);
            }
        }

        [HttpPost]
        public IActionResult PostEndereco(Endereco endereco)
        {
            using (var _context = new HotelContext()){
                try{
                    _context.Endereco.Add(endereco);
                    _context.SaveChanges();
                }catch{
                    return BadRequest("Erro ao cadastrar cliente!");
                }
                return Ok(endereco);
            }
        }

        [HttpPut]
        public  IActionResult PutEndereco(Endereco endereco)
        {
            using (var _context = new HotelContext()){
                var enderecoBanco =  _context.Endereco.Find(endereco.IdEndereco);

                if (enderecoBanco == null)
                {
                    return NotFound("Endereço não encontrado!");
                }
                try{
                    _context.Entry(enderecoBanco).CurrentValues.SetValues(endereco);
                    _context.SaveChanges();
                    return Ok(endereco);
                }catch{
                    return BadRequest("Erro ao editar endereço!");
                }
            }
        }

        [HttpDelete]
        public  IActionResult DeleteEndereco(int id)
        {
            using (var _context = new HotelContext()){
                var enderecoBanco =  _context.Endereco.Find(id);

                if (enderecoBanco == null)
                {
                    return NotFound("Endereço não encontrado!");
                }
                try{
                    _context.Endereco.Remove(enderecoBanco);
                    _context.SaveChanges();
                    return Ok();
                }catch{
                    return BadRequest("Erro ao deletar endereço!");
                }
            }
        }

    }
}