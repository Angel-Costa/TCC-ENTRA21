using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public SistemaContext context;

        public LoginRepository(SistemaContext context)
        {
            this.context = context;
        }

        public bool Alterar(Login login)
        {
            Login loginOriginal = context.Logins.FirstOrDefault(x => x.Id == login.Id);
            if(loginOriginal == null)
            {
                return false;
            }

            loginOriginal.Email = login.Email;
            loginOriginal.Senha = login.Senha;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            var login = context.Logins.FirstOrDefault(x => x.Id == id);
            login.RegistroAtivo = false;
            return context.SaveChanges() == 1;
        }

        public int Inserir(Login login)
        {
            login.RegistroAtivo = true;
            context.Logins.Add(login);
            context.SaveChanges();
            return login.Id;
        }
        public Login ObterPeloId(int id)
        {
            return context.Logins.FirstOrDefault(x => x.Id == id && x.RegistroAtivo);
        }

        public List<Login> ObterTodos()
        {
            return context.Logins.Where(x => x.RegistroAtivo).ToList();
        }
    }
}
