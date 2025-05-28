using APIClientes.Services.DTOs;
using APIClientes.Services.Exceptions;

namespace APIClientes.Services.Validacoes
{
    public static class EnderecoValidation
    {
        public static void ValidarCriarEndereco(CriarEnderecoDTO dto)
        {
            if (dto.Cep <= 0)
                throw new BadRequestException("CEP é obrigatório");

            if (string.IsNullOrWhiteSpace(dto.Logradouro))
                throw new BadRequestException("Logradouro é obrigatório");

            if (string.IsNullOrWhiteSpace(dto.Numero))
                throw new BadRequestException("Número é obrigatório");

            if (string.IsNullOrWhiteSpace(dto.Bairro))
                throw new BadRequestException("Bairro é obrigatório");

            if (string.IsNullOrWhiteSpace(dto.Cidade))
                throw new BadRequestException("Cidade é obrigatória");

            if (string.IsNullOrWhiteSpace(dto.Uf))
                throw new BadRequestException("UF é obrigatória");
        }
    }
}
