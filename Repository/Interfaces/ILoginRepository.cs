using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface ILoginRepository
    {
        int Inserir(Login login);

        bool Alterar(Login login);

        List<Login> ObterTodos();

        Login ObterPeloId(int id);

        bool Apagar(int login);
    }
}
