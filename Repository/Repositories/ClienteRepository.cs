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

        public ClienteRepository(SistemaContext context)
        {
            this.context = context;
        }

        public bool Alterar(Cliente cliente)
        {
            cliente.RegistroAtivo = true;
            context.Clientes.Update(cliente);
            return context.SaveChanges() == 1;
        }

        public bool Apagar(int idCliente)
        {
            var cliente = context.Clientes.FirstOrDefault(y => y.Id == idCliente);
            if (cliente == null)
                return false;

            cliente.RegistroAtivo = false;
            context.Clientes.Update(cliente);
            return context.SaveChanges() == 1;
        }

        public int Inserir(Cliente cliente)
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

        public List<Cliente> ObterTodos(int id)
        {
            return context.Clientes
             .Where(x => x.RegistroAtivo).ToList()
             .ToList();
        }


        
    }
}
