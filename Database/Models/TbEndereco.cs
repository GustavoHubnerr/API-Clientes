﻿using System;
using System.Collections.Generic;

namespace APIClientes.Database.Models;

public partial class TbEndereco
{
    public int Id { get; set; }
    public int Cep { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Uf { get; set; }
    public int Clienteid { get; set; }
    public int Status { get; set; }
    public virtual TbCliente Cliente { get; set; }
}
