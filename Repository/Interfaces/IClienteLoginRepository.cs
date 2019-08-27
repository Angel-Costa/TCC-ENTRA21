using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IClienteLoginRepository
    {
        int Relacionar(ClienteLogin clienteLogin);

        bool Apagar(int id);

        List<ClienteLogin> ObterTodosPeloIdCliente(int idCliente);

        ClienteLogin ObterPeloId(int id);
    }
}
