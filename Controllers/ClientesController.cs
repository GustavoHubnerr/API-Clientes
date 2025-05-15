using APIClientes.Database.Models;
using APIClientes.Services;
using APIClientes.Services.DTOs;
using APIClientes.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _service;
        public ClientesController(ClientesService service)
        {
            _service = service;
        }
        [HttpPost]
        public ActionResult<ClienteDTO>
            Adicionar([FromBody] CriarClienteDTO body)
        {
            try
            {
                var Response = _service.Criar(body);
                return Ok(Response);//200
            }
            catch (BadRequestException B)
            {
                return BadRequest(B.Message);//400
            }
            catch (System.Exception E)
            {
                return StatusCode(500, E.Message);//500
            }
           
        }

        [HttpGet]
        public ActionResult<List<ClienteDTO>> ListarTodos()
        {
            var lista = _service.ListarTodos();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteDTO> BuscarPorId(int id)
        {
            try
            {
                var cliente = _service.BuscarPorId(id);
                return Ok(cliente);
            }
            catch (BadRequestException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent(); // 204
            }
            catch (BadRequestException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public ActionResult<ClienteDTO> Atualizar(int id, [FromBody] CriarClienteDTO body)
        {
            try
            {
                var atualizado = _service.Atualizar(id, body);
                return Ok(atualizado); // 200
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message); // 400
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message); // 500
            }
        }



    }
}
