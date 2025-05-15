using APIClientes.Database.Models;
using APIClientes.Services.DTOs;
using System;

namespace APIClientes.Services.Parses
{
    public class ClienteParser
    {
        private static object novoCliente;

        public static TbCliente ToTbCliente(
            CriarClienteDTO dto)
        {
            TbCliente novoCliente = new();
            novoCliente.Nome = dto.Nome;
            novoCliente.Telefone = dto.Telefone;
            novoCliente.Nascimento = dto.Nascimento;
            novoCliente.Documento = dto.Documento;
            novoCliente.Tipodoc = dto.Tipodoc;
            novoCliente.Criadoem = DateTime.Now.ToUniversalTime();
            novoCliente.Alteradoem = novoCliente.Criadoem;

            return novoCliente;
        }

        public static ClienteDTO ToClienteDTO(
            TbCliente novoCliente)
        {
            ClienteDTO Response = new();
            Response.Id = novoCliente.Id;
            Response.Nome = novoCliente.Nome;
            Response.Criadoem = novoCliente.Criadoem;
            Response.Alteradoem = novoCliente.Alteradoem;
            Response.Telefone = novoCliente.Telefone;
            Response.Documento = novoCliente.Documento;
            Response.Nascimento = novoCliente.Nascimento;
            Response.Tipodoc = novoCliente.Tipodoc;

            return Response;
        }
    }
}
