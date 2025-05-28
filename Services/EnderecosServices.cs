using APIClientes.Database.Models;
using APIClientes.Services.DTOs;
using APIClientes.Services.Exceptions;
using APIClientes.Services.Parses;
using APIClientes.Services.Validacoes;
using System.Linq;

namespace APIClientes.Services
{
    public class EnderecosService
    {
        private readonly ClientesContext _dbcontext;

        public EnderecosService(ClientesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public EnderecoDTO Criar(int clienteId, CriarEnderecoDTO dto)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == clienteId);
            if (cliente == null)
                throw new BadRequestException("Cliente não encontrado");

            var enderecoExistente = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Clienteid == clienteId);
            if (enderecoExistente != null)
                throw new BadRequestException("O cliente já possui um endereço cadastrado");

            EnderecoValidation.ValidarCriarEndereco(dto);

            var novoEndereco = EnderecoParser.ToTbEndereco(dto, clienteId);

            _dbcontext.TbEnderecos.Add(novoEndereco);
            _dbcontext.SaveChanges();

            return EnderecoParser.ToEnderecoDTO(novoEndereco);
        }

        public EnderecoDTO BuscarPorClienteId(int clienteId)
        {
            var endereco = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Clienteid == clienteId);
            if (endereco == null)
                throw new BadRequestException("Endereço não encontrado para esse cliente");

            return EnderecoParser.ToEnderecoDTO(endereco);
        }

        public EnderecoDTO Atualizar(int clienteId, CriarEnderecoDTO dto)
        {
            var endereco = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Clienteid == clienteId);
            if (endereco == null)
                throw new BadRequestException("Endereço não encontrado para esse cliente");

            EnderecoValidation.ValidarCriarEndereco(dto);

            endereco.Cep = dto.Cep;
            endereco.Logradouro = dto.Logradouro;
            endereco.Numero = dto.Numero;
            endereco.Complemento = dto.Complemento;
            endereco.Bairro = dto.Bairro;
            endereco.Cidade = dto.Cidade;
            endereco.Uf = dto.Uf;

            _dbcontext.SaveChanges();

            return EnderecoParser.ToEnderecoDTO(endereco);
        }

        public void Remover(int clienteId)
        {
            var endereco = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Clienteid == clienteId);
            if (endereco == null)
                throw new BadRequestException("Endereço não encontrado para esse cliente");

            _dbcontext.TbEnderecos.Remove(endereco);
            _dbcontext.SaveChanges();
        }
    }
}
