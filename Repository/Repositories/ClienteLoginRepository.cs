using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ClienteLoginRepository : IClienteLoginRepository
    {
        private SistemaContext context;

        public ClienteLoginRepository()
        {
           this.context = new SistemaContext();
        }

        public bool Apagar(int idClienteLogin, int id)
        {
            Cliente cliente = (
                from clientes in context.Clientes
                where clientes.Id == id
                select clientes).FirstOrDefault();
            if(cliente == null)
            {
                return false;
            }

            cliente.RegistroAtivo = false;
            context.SaveChanges();
            return true;

        }

       
        public ClienteLogin ObterPeloId(int id)
        {
            return (from clienteLogin in context.ClientesLogins
                    where clienteLogin.Id == id
                    select clienteLogin).FirstOrDefault();
        }

        public List<ClienteLogin> ObterTodosPeloIdCliente(int idCliente)
        {
            return context.ClientesLogins                
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
