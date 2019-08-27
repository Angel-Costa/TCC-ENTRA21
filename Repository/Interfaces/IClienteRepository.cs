﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IClienteRepository
    {

        int Inserir(Cliente cliente);

        bool Alterar(Cliente cliente);

        List<Cliente> ObterTodos();

        Cliente ObterPeloId(int id);

        bool Apagar(int id);
    }
}
