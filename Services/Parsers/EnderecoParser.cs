using APIClientes.Database.Models;
using APIClientes.Services.DTOs;

namespace APIClientes.Services.Parses
{
    public static class EnderecoParser
    {
        public static EnderecoDTO ToEnderecoDTO(TbEndereco endereco)
        {
            return new EnderecoDTO
            {
                Id = endereco.Id,
                Cep = endereco.Cep,
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Uf = endereco.Uf,
                ClienteId = endereco.Clienteid
            };
        }
        public static TbEndereco ToTbEndereco(CriarEnderecoDTO dto, int clienteId)
        {
            return new TbEndereco
            {
                Cep = dto.Cep,
                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Uf = dto.Uf,
                Clienteid = clienteId,
                Status = 1
            };
        }
    }
}
