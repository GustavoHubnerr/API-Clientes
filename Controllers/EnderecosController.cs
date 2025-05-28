using APIClientes.Services;
using APIClientes.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace APIClientes.Controllers
{
    [ApiController]
    [Route("api/cliente/{id}/endereco")]
    public class EnderecosController : ControllerBase
    {
        private readonly EnderecosService _service;

        public EnderecosController(EnderecosService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult BuscarPorClienteId(int id)
        {
            var endereco = _service.BuscarPorClienteId(id);
            return Ok(endereco);
        }

        [HttpPost]
        public IActionResult Criar(int id, [FromBody] CriarEnderecoDTO dto)
        {
            var endereco = _service.Criar(id, dto);
            return CreatedAtAction(nameof(BuscarPorClienteId), new { id = endereco.ClienteId }, endereco);
        }

        [HttpPatch]
        public IActionResult Atualizar(int id, [FromBody] CriarEnderecoDTO dto)
        {
            var endereco = _service.Atualizar(id, dto);
            return Ok(endereco);
        }

        [HttpDelete]
        public IActionResult Remover(int id)
        {
            _service.Remover(id);
            return NoContent();
        }
    }
}
