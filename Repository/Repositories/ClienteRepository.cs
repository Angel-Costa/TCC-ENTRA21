using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            var clienteAux = context.Clientes
                .Where(x => x.Id == cliente.Id)
                .FirstOrDefault();

            if (clienteAux == null)
                return false;

            clienteAux.Nome = cliente.Nome;
            clienteAux.Celular = cliente.Celular;

            clienteAux.Login = cliente.Login;
            clienteAux.Senha = cliente.Senha;

            clienteAux.Rua = cliente.Rua;
            clienteAux.Estado = cliente.Estado;
            clienteAux.Complemento = cliente.Complemento;
            clienteAux.Numero = cliente.Numero;
            clienteAux.Cep = cliente.Cep;
            clienteAux.Bairro = cliente.Bairro;
            clienteAux.RegistroAtivo = true;

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

        public Cliente VerificarLoginSenha(string login, string senha)
        {
            return context.Clientes.FirstOrDefault(x => x.Login == login && x.Senha == senha && x.RegistroAtivo);
        }
    }
}
