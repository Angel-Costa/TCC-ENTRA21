using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class ClienteLoginRepository : IClienteLogin
    {
        private SistemaContext context;

        public ClienteLoginRepository(SistemaContext context)
        {
            this.context = context;
        }

        public bool Apagar(int idClienteLogin)
        {
            var clienteLogin = context.ClientesLogins.FirstOrDefault(x => x.IdCliente == idClienteLogin);
            clienteLogin.RegistroAtivo = false;
            context.Update(clienteLogin);
            return context.SaveChanges() == 1;
        }

        public ClienteLogin ObterPeloId(int id)
        {
            return context.ClientesLogins.FirstOrDefault(x => x.Id == id);
        }

        public List<ClienteLogin> ObterTodosPeloIdCliente(int idCliente)
        {
            return context.ClientesLogins
                .Include(x => x.Login)
                .Where(x => x.IdCliente == idCliente).ToList();
        }

        public int Relacionar(ClienteLogin clienteLogin)
        {
            context.ClientesLogins.Add(clienteLogin);
            context.SaveChanges();
            return clienteLogin.Id;
        }
    }
}
