using APIClientes.Database.Models;
using APIClientes.Services.DTOs;
using APIClientes.Services.Exceptions;
using APIClientes.Services.Parses;
using APIClientes.Services.Validacoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace APIClientes.Services
{
    public class ClientesService
    {
        private readonly ClientesContext _dbcontext;
        public ClientesService(ClientesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public ClienteDTO Criar(CriarClienteDTO dto)
        {
            ClienteValidation.ValidarCriarCliente(dto);

            TbCliente novoCliente =
                ClienteParser.ToTbCliente(dto);
          

            _dbcontext.TbClientes.Add(novoCliente);
            _dbcontext.SaveChanges();

           
            return ClienteParser.ToClienteDTO(novoCliente);
        }

        public List<ClienteDTO> ListarTodos()
        {
            return _dbcontext.TbClientes
                .Select(c => ClienteParser.ToClienteDTO(c))
            .ToList();
        }

        public ClienteDTO BuscarPorId(int id)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                throw new BadRequestException("Cliente não encontrado");

            return ClienteParser.ToClienteDTO(cliente);
        }
        public void Remover(int id)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                throw new BadRequestException("Cliente não encontrado");

            _dbcontext.TbClientes.Remove(cliente);
            _dbcontext.SaveChanges();
        }

        public ClienteDTO Atualizar(int id, CriarClienteDTO dto)
        {
            ClienteValidation.ValidarCriarCliente(dto);

            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                throw new BadRequestException("Cliente não encontrado");

            cliente.Nome = dto.Nome;
            cliente.Nascimento = dto.Nascimento;
            cliente.Telefone = dto.Telefone;
            cliente.Documento = dto.Documento;
            cliente.Tipodoc = dto.Tipodoc;
            cliente.Alteradoem = DateTime.Now.ToUniversalTime();

            _dbcontext.SaveChanges();

            return ClienteParser.ToClienteDTO(cliente);
        }
    }
}
