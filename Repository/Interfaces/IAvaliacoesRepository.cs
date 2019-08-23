using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IAvaliacoesRepository
    {
        int Inserir(Avaliacao avaliacao);

        bool Alterar(Avaliacao avaliacao);

        List<Avaliacao> ObterTodos();

        Avaliacao ObterPeloId(int id);

        bool Apagar(int id);
    }
}
