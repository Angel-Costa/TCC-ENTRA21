using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public SistemaContext context;

        public ClienteRepository()
        {
            this.context = new SistemaContext();
        }

        public bool Alterar(Cliente cliente)
        {
            cliente.RegistroAtivo = true;
            return context.SaveChanges() == 1;
        }

        public bool Apagar(int id)
        {
            var cliente = context.Clientes.FirstOrDefault(y => y.Id == id);
            if (cliente == null)
                return false;

            cliente.RegistroAtivo = false;
            return context.SaveChanges() == 1;
        }

        public int Cadastro(Cliente cliente)
        {
            cliente.RegistroAtivo = true;
            context.Clientes.Add(cliente);
            context.SaveChanges();
            return cliente.Id;
        }

        public Cliente ObterPeloId(int id)
        {
            return context.Clientes
             .FirstOrDefault(x => x.Id == id && x.RegistroAtivo);
        }

        public List<Cliente> ObterTodos()
        {
            return context.Clientes
             .Where(x => x.RegistroAtivo).ToList();
             
        }        
    }
}
