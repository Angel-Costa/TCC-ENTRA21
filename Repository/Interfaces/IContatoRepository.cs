using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IContatoRepository
    {
        int Inserir(Contato contato);

        bool Alterar(Contato contato);

        List<Contato> ObterTodos();

        Contato ObterPeloId(int id);

        bool Apagar(int id);

    }
}
