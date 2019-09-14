using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Repository.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private SistemaContext context;

        public AdministradorRepository()
        {
            this.context = new SistemaContext();
        }

        public bool Alterar(Administrador administrador)
        {
            Administrador administradorOriginal = context.Administradores.FirstOrDefault(x => x.Id == administrador.Id);
            if (administradorOriginal == null)
            {
                return false;
            }

            administradorOriginal.Nome = administrador.Nome;
            administradorOriginal.Cpf = administrador.Cpf;
            administradorOriginal.Login = administrador.Login;
            administradorOriginal.Senha = administrador.Senha;

            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            var administrador = context.Administradores.FirstOrDefault(y => y.Id == id);
            if (administrador == null)
                return false;

            administrador.RegistroAtivo = false;
            return context.SaveChanges() == 1;
        }

        public int Inserir(Administrador administrador)
        {
            administrador.Privilegio = "Adminisrtador";
            administrador.RegistroAtivo = true;
            context.Administradores.Add(administrador);
            context.SaveChanges();
            return administrador.Id;
        }

        public Administrador ObterPeloId(int id)
        {
            return context.Administradores.FirstOrDefault(x => x.Id == id && x.RegistroAtivo);
        }

        public List<Administrador> ObterTodos()
        {
            return context.Administradores
                .Where(x => x.RegistroAtivo).ToList();
        }
    }


}
