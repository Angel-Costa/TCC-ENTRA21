using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IClienteLogin
    {
        int Relacionar(ClienteLogin clienteLogin);

        bool Apagar(int idClienteLogin);

        List<ClienteLogin> ObterTodosPeloIdCliente(int idCliente);

        ClienteLogin ObterPeloId(int id);
    }
}
