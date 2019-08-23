using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IComodidadeRepository
    {
        int Inserir(Comodidade comodidade);

        bool Alterar(Comodidade comodidade);

        List<Comodidade> ObterTodos();

        Comodidade ObterPeloId(int id);

        bool Apagar(int id);
    }
}
