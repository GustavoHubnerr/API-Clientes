using APIClientes.Services.DTOs;
using APIClientes.Services.Exceptions;
using System.Linq;

namespace APIClientes.Services.Validacoes
{
    public class ClienteValidation
    {
        public static void ValidarCriarCliente(
            CriarClienteDTO criarClienteDTO)
        {
            if (string.IsNullOrEmpty(criarClienteDTO.Nome))
                throw new BadRequestException(
                    "Nome é obrigatorio");

            if (string.IsNullOrEmpty(criarClienteDTO.Documento))
                throw new BadRequestException(
                    "Documento é obrigatorio");

            if (!new[] { 0, 1, 2, 3, 99 }.Contains(
                criarClienteDTO.Tipodoc))
                throw new BadRequestException(
                    "Tipo de documento não suportado");

        }
    }
}
