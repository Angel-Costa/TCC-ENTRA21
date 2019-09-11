using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ISugestaoRepository
    {
        int Inserir(Sugestao sugestao);

        bool Alterar(Sugestao sugestao);

        List<Sugestao> ObterTodos();

        Sugestao ObterPeloId(int id);

        bool Apagar(int id);
    }
}